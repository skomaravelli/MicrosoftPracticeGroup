using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncryptConfig
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var conectionString = ConfigurationManager.ConnectionStrings["MyConnString"];
            txtBox.Text = conectionString.ToString();
           
        }

        string provider = "RSAProtectedConfigurationProvider";
        string section = "connectionStrings";

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                ConfigurationSection confStrSect = config.GetSection(section);
                if (confStrSect != null)
                {
                    confStrSect.SectionInformation.ProtectSection(provider);
                    config.Save();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                ConfigurationSection confStrSect = config.GetSection(section);
                if (confStrSect != null && confStrSect.SectionInformation.IsProtected)
                {
                    confStrSect.SectionInformation.UnprotectSection();
                    config.Save();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}