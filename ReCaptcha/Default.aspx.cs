using System;
using System.Web.UI;

namespace ReCaptcha.Site
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        protected void SubmitForm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ContactForm.Visible = false;
                ThankYouMessage.Visible = true;
            }
        }
    }
}