using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UpdatePanel up1 = new UpdatePanel();
        up1.ID = "UpdatePanel1";
        up1.UpdateMode = UpdatePanelUpdateMode.Conditional;
        Button button1 = new Button();
        button1.ID = "Button1";
        button1.Text = "Submit";
        button1.Click += new EventHandler(button1_Click);
        Label label1 = new Label();
        label1.ID = "Label1";
        label1.Text = "A full page postback occurred.";
        up1.ContentTemplateContainer.Controls.Add(button1);
        up1.ContentTemplateContainer.Controls.Add(label1);
        Page.Form.Controls.Add(up1);
    }

    protected void button1_Click(object sender, EventArgs e)
    {
        ((Label)Page.FindControl("Label1")).Text = "Panel refreshed at " +
            DateTime.Now.ToString();
    }
}