using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net.Layout;

namespace Log4NetCustomSQL
{
    public class MyLayout : PatternLayout
    {
        public MyLayout()
        {
            this.AddConverter("property", typeof(MyMessagePatternConverter));
        }
    }
}