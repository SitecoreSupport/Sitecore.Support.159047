using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Support.Shell.Applications.Dialogs.GeneralLink
{
    public class GeneralLinkForm : Sitecore.Shell.Applications.Dialogs.GeneralLink.GeneralLinkForm
    {
        private string CurrentMode
        {
            get
            {
                string text = base.ServerProperties["current_mode"] as string;
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                return "internal";
            }
            set
            {
                Assert.ArgumentNotNull(value, "value");
                base.ServerProperties["current_mode"] = value;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            Assert.ArgumentNotNull(e, "e");
            base.OnLoad(e);
            if (CurrentMode.Equals("mailto",StringComparison.InvariantCultureIgnoreCase))
                if (base.LinkAttributes["url"].StartsWith("mailto:"))
                {
                   // base.LinkAttributes["url"] =
                    this.MailToLink.Value = base.LinkAttributes["url"].Remove(0, 7);
                }
        }
    }
}