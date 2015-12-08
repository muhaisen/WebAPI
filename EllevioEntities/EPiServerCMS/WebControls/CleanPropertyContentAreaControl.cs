using EPiServer.Web.PropertyControls;
using EPiServer.Web.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace EllevioCore.EPiServerCMS.WebControls
{
    public class CleanPropertyContentAreaControl : PropertyContentAreaControl
    {
        public override void CreateDefaultControls()
        {
            var controlList = GetContentRenderers(false);

            foreach (var control in controlList)
            {
                var contentRender = control as ContentRenderer;
                if (contentRender == null)
                {
                    continue;
                }
                contentRender.EnsureChildControlsCreated();
                foreach (Control ctrl in contentRender.Controls)
                {
                    Controls.Add(ctrl);
                }
            }
        }
    }
}
