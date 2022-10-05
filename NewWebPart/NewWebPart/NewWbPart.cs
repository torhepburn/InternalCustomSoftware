using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace NewWebPart
{
    public class NewWbPart : WebPart
    {
        protected override void CreateChildControls()
        {
            Calendar cldr = new Calendar();
            cldr.Enabled = true;
            cldr.ShowGridLines = true;
            cldr.ShowTitle = true;
            cldr.EnableViewState = true;
            cldr.SelectedDate = DateTime.Now;

            Controls.Add(cldr);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            RenderChildren(writer);
        }
    }
}
