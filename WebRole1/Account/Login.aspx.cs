using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
//using IntranetDL;
//using IntranetPL;
using System.Web.Security;


namespace WebRole1
{
    public partial class Account_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!IsPostBack)
            {
                //DL_Employee objUser = new DL_Employee();
                //string strCaptcha = objUser.GetCaptchaCode();
                //CaptchaCodeValue.Text = strCaptcha;

                /*if (objUser != null)
                    objUser = null;*/
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
            /*string strUserame = UserName.Text;
            string strPassword = Password.Text;
            string strCaptcha = UserEntry.Text;

            DL_Employee objUser = new DL_Employee();
            if (strCaptcha.ToUpper() == CaptchaCodeValue.Text.ToUpper())
            {   
                bool blnAccess = objUser.CheckUserAccess(strUserame, strPassword, strCaptcha);

                if (blnAccess)
                {
                    Session["UserName"] = strUserame;
                    Response.Redirect("../Index.aspx");
                }
                else
                    LoginUserValidationSummary.HeaderText = "Invalid User credentials. Please try again.";

            }
            else
            {
                LoginUserValidationSummary.HeaderText = "Please enter the Captcha code correctly as displayed. Kindly try again.";
            }
            if (objUser != null)
                objUser = null;*/
        }
    }

}