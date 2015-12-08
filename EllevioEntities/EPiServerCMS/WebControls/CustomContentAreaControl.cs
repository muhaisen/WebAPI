using EPiServer.Web.PropertyControls;
using EPiServer.Web.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EllevioCore.EPiServerCMS.WebControls
{
    public class CustomContentAreaControl : PropertyContentAreaControl
    {
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            // TODO: Try to remove extra container created by PropertyContentAreaControl
            var container = Controls.Count > 0 ? Controls[0] : null;
            if (container == null)
            {
                return;
            }

            foreach (var control in container.Controls)
            {
                var webControl = control as WebControl;
                if (webControl != null)
                {
                    webControl.CssClass = String.Join(" ", GetClasses(webControl));
                    continue;
                }
                var htmlControl = control as HtmlControl;
                if (htmlControl != null)
                {
                    htmlControl.Attributes.Add("class", String.Join(" ", GetClasses(htmlControl)));
                }
            }
        }

        private IEnumerable<string> GetClasses(Control control)
        {
            var classes = new List<string>() {
                "block",
            };

            var renderer = control as ContentRenderer;
            if (renderer != null)
            {
                var content = renderer.ContentAreaItem.ContentLink;

                if (content != null)
                {

                    classes.Add(content.GetType().Name.ToLowerInvariant());
                    classes.Add(renderer.Tag);
                    classes.Add(GetCssClassForTag(renderer.Tag));
                }
            }

            if (PropertyIsEditableForCurrentLanguage())
            {
                classes.Add("clearfix");
            }

            return classes;
        }

        /// <summary>
        /// Gets a CSS class used for styling based on a tag name (ie a Bootstrap class name)
        /// </summary>
        /// <param name="tagName">Any tag name available, see <see cref="Global.ContentAreaTags"/></param>
        private static string GetCssClassForTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                return "col-lg-12 col-md-12 col-sm-12";
            }
            switch (tagName.ToLower())
            {
                case "span12":
                    return "col-lg-12 col-md-12 col-sm-12";
                case "span6":
                    return "col-lg-6 col-md-12 col-sm-12";
                case "span3":
                    return "col-lg-3 col-md-6 col-sm-12";
                default:
                    return String.Empty;
            }
        }
       
    }
}
