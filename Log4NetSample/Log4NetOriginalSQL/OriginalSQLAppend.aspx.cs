﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Log4NetOriginalSQL
{
    public partial class OriginalSQLAppend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LogsManager.InfoLogWrite(DateTime.Now.ToString() + ":插入的内容\r\n");
        }
    }
}