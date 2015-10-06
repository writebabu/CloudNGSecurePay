using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole1.App_Code.DL;

namespace WebRole1.App_Code.BL
{
    public class BL_Employee
    {
        private DL_Employee objDL = new DL_Employee();

        public BL_Employee()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /*public int SaveErrorMessage(string errorMsg)
        {
            return objDL.SaveErrorMessage(errorMsg);
        }*/

        public int SendFeedbackMail(Int64 CreatedBy, string CreatedByName, string CreatedByEmail, string Message)
        {
            return objDL.SendFeedbackMail(CreatedBy, CreatedByName, CreatedByEmail, Message);
        }

        public int SavePageHitsCount(string vzID, string toolCode, string pageName, string hostAddress, string serverIP)
        {
            return objDL.SavePageHitsCount(vzID, toolCode, pageName, hostAddress, serverIP);
        }
    }
}