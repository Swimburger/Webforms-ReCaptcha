<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReCaptcha.Site.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="ContactForm" Visible="true">
        <br />
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtName" placeholder="Name" CssClass="form-control"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" Text="Name is required" />
                </div>
            </div>
        </div>

        <ReCaptchaLib:Challenge
            runat="server"
            ID="RecaptchaChallenge" />
        <ReCaptchaLib:ReCaptchaValidator
            runat="server"
            ControlToValidate="RecaptchaChallenge"
            Text="ReCaptcha failed, are you a robot?"
            Display="Dynamic" />

        <asp:Button runat="server" OnClick="SubmitForm_Click" Text="Submit" CssClass="btn btn-primary" />
    </asp:Panel>
    <asp:Panel runat="server" ID="ThankYouMessage" Visible="false">
        <p>Thank you for contacting us</p>
    </asp:Panel>
</asp:Content>
