using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace WebRole1.App_Code.DL
{
    public class DL_Employee
    {
        private string strConnection = ConfigurationManager.AppSettings["ConnectionString"].ToString();

        public DL_Employee()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GetCaptchaCode()
        {
            string strCaptcha = "";
            using (SqlConnection myConnection = new SqlConnection(strConnection))
            {
                using (SqlCommand myComand = new SqlCommand("Usp_GetCaptchaCode", myConnection))
                {
                    myComand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using (SqlDataReader myReader = myComand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                strCaptcha = myReader["Captchacode"].ToString();
                            }
                        }
                        myReader.Close();
                    }
                }
                myConnection.Close();
            }
            return strCaptcha;
        }

        public bool CheckUserAccess(string strUsername, string strPassword, string strCaptcha)
        {
            bool blnAccess = false;
            string strAccess = "";
            using (SqlConnection myConnection = new SqlConnection(strConnection))
            {
                using (SqlCommand myComand = new SqlCommand("USP_Login", myConnection))
                {
                    myComand.CommandType = CommandType.StoredProcedure;
                    myComand.Parameters.AddWithValue("@Uname", strUsername);
                    myComand.Parameters.AddWithValue("@Pass", strPassword);
                    myComand.Parameters.AddWithValue("@Captcha", strCaptcha);
                    myConnection.Open();
                    using (SqlDataReader myReader = myComand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                strAccess = myReader[0].ToString();
                                if (strAccess == "1")
                                    blnAccess = true;
                            }
                        }
                        myReader.Close();
                    }
                }
                myConnection.Close();
            }
            return blnAccess;
        }


        public int SendFeedbackMail(Int64 CreatedBy, string CreatedByName, string CreatedByEmail, string Message)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(strConnection))
            {
                using (SqlCommand myCommand = new SqlCommand("USP_InsertFeedbackMails", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (CreatedBy != null && CreatedBy != 0)
                        myCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    else
                        myCommand.Parameters.AddWithValue("@CreatedBy", DBNull.Value);

                    if (!string.IsNullOrEmpty(CreatedByName))
                        myCommand.Parameters.AddWithValue("@CreatedByName", CreatedByName);
                    else
                        myCommand.Parameters.AddWithValue("@CreatedByName", DBNull.Value);

                    if (!string.IsNullOrEmpty(CreatedByEmail))
                        myCommand.Parameters.AddWithValue("@CreatedByEmail", CreatedByEmail);
                    else
                        myCommand.Parameters.AddWithValue("@CreatedByEmail", DBNull.Value);

                    if (!string.IsNullOrEmpty(Message))
                        myCommand.Parameters.AddWithValue("@Message", Message);
                    else
                        myCommand.Parameters.AddWithValue("@Message", DBNull.Value);


                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result;
        }




        public int SavePageHitsCount(string vzID, string toolCode, string pageName, string hostAddress, string serverIP)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(strConnection))
            {
                using (SqlCommand myCommand = new SqlCommand("Usp_Hdr_LogVisit", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(vzID))
                        myCommand.Parameters.AddWithValue("@VZID", vzID);

                    if (!string.IsNullOrEmpty(toolCode))
                        myCommand.Parameters.AddWithValue("@ToolCode", toolCode);

                    if (!string.IsNullOrEmpty(pageName))
                        myCommand.Parameters.AddWithValue("@PageName", pageName);

                    if (!string.IsNullOrEmpty(hostAddress))
                        myCommand.Parameters.AddWithValue("@HostAddress", hostAddress);

                    if (!string.IsNullOrEmpty(serverIP))
                        myCommand.Parameters.AddWithValue("@serverIP", serverIP);


                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result;
        }
    }
}