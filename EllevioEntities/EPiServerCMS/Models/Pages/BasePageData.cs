using EllevioCore.EPiServerCMS.CustomizationClasses;
using EllevioCore.EPiServerCMS.Models.Properties;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace EllevioCore.EPiServerCMS.Models.Pages
{
    public class BasePageData : PageData
    {
        [Display(
            GroupName = Tabs.MetaData,
            Name = "Titel",
            Order = 700)]
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                var metaTitle = this.GetPropertyValue(p => p.MetaTitle);

                // Use explicitly set meta title, otherwise fall back to page name
                return !string.IsNullOrWhiteSpace(metaTitle)
                       ? metaTitle
                       : PageName;
            }
            set { this.SetPropertyValue(p => p.MetaTitle, value); }
        }
        [Display(
            GroupName = Tabs.MetaData,
            Name = "Beskrivning",
            Order = 900)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string MetaDescription { get; set; }

        [Display(
            GroupName = Tabs.MetaData,
            Name = "Nyckelord",
            Order = 800)]
        [CultureSpecific]
        [BackingType(typeof(PropertyStringList))]
        public virtual string[] MetaKeywords { get; set; }
    }
}