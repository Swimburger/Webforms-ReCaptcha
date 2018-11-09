using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReCaptcha.Library
{
    public class ReCaptchaValidator : CustomValidator
    {
        protected override bool ControlPropertiesValid()
        {
            var reCaptcha = FindControl(ControlToValidate) as Challenge;
            return (reCaptcha != null);
        }

        protected override bool EvaluateIsValid()
        {
            var reCaptchaFormValue = Page.Request.Form["g-Recaptcha-Response"];
            if (string.IsNullOrEmpty(reCaptchaFormValue))
            {
                return false;
            }

            var secret = ConfigurationManager.AppSettings["ReCaptchaLib.SecretKey"];
            var client = new WebClient();
            var reCaptchaVerificationUrl = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={reCaptchaFormValue}");
            ReCaptchaResponse reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(reCaptchaVerificationUrl);

            return reCaptchaResponse.IsHuman;
        }
    }
}