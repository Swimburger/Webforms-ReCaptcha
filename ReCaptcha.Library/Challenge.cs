using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReCaptcha.Library
{
    [ToolboxData("<{0}:Challenge runat=server></{0}:ReCaptcha>")]
    public class Challenge : WebControl
    {
        protected override void RenderContents(HtmlTextWriter output)
        {
            var template = $@"
                <div 
                    class=""g-recaptcha""
                    data-sitekey=""{ConfigurationManager.AppSettings["ReCaptchaLib.SiteKey"]}""
                    data-size=""invisible"">
                </div>";
            output.Write(template);
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            // emit the JS file into the page so you won't need to add it manually
            Page.ClientScript.RegisterClientScriptResource(
                typeof(ReCaptchaValidator),
                "ReCaptcha.Library.ReCaptchaValidation.js");

            base.OnPreRender(e);
        }
    }
}
