using EllevioCore.EPiServerCMS.CustomizationClasses;
using EllevioCore.EPiServerCMS.Models.Properties;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllevioCore.EPiServerCMS.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "16f25951-4438-41c5-a9a7-1089857a6fca", Description = "Startsida")]
    public class StartPage : BasePageData
    {
        [BackingType(typeof(PropertyContentArea))]
        [Display(
            Name = "Innehållsyta för informationsidor",
            Description = "Yta avsedd för informationsidor.",
            GroupName = SystemTabNames.Content,
           Order = 20)]
        public virtual ContentArea ContentAreaBottom { get; set; }

        [BackingType(typeof(PropertyContentArea))]
        [Display(
            Name = "Innehållsyta för sök resa",
            Description = "Blockyta för sök resa",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual ContentArea BookingPageContentArea { get; set; }

        [Editable(true)]
        [Required]
        [Display(
            Name = "Länk till inställningssidan",
            Description = "här pekas inställningssidan ut.",
            GroupName = Tabs.GlobalPages,
            Order = 10)]
        public virtual PageReference SettingsPage { get; set; }

        [Display(
        GroupName = Tabs.MetaData,
        Name = "Titel",
        Order = 100)]
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
            Order = 300)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string MetaDescription { get; set; }

        [Display(
            GroupName = Tabs.MetaData,
            Name = "Nyckelord",
            Order = 200)]
        [CultureSpecific]
        [BackingType(typeof(PropertyStringList))]
        public virtual string[] MetaKeywords { get; set; }
    }
}
