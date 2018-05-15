using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Log4NetOriginalSQL
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //注册 log4net(或者在AssemblyInfo.cs中添加注册的方法)
            System.IO.FileInfo configFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("log4net.config"));
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
    }
}