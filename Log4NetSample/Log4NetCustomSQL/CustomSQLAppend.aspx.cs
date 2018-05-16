using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Log4NetCustomSQL
{
    public partial class CustomSQLAppend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LogContent logmodel = new LogContent();
            logmodel.Event_Type = 3;
            logmodel.EventCategory = "登陆系统";
            logmodel.Event_ID = 1;
            logmodel.ComputerName = Request.UserHostAddress;
            logmodel.Mac_Address = "192.168.1.1";
            logmodel.Source = "SS";
            logmodel.SourceType = "1";
            logmodel.UserName = "ADMIN";
            logmodel.Description = "TEST";

            LogHelper.InfoLogInsert(logmodel);
        }
    }
}