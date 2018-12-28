using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitWebConfig
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var appValue = ConfigurationManager.AppSettings["MyKey1"];
            var sectionValue = ConfigurationManager.GetSection("testsection1") as NameValueCollection;
            var value = sectionValue["MyKey1"];
            var conectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
        }
    }
}