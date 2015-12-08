using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer;
using EllevioCore.EPiServerCMS.CustomizationClasses;

namespace EllevioCore.EPiServerCMS.Models.Pages
{
    [ContentType(DisplayName = "Settings Page", GUID = "11116280-243F-4D98-AEEB-424F06534BA1", Description = "")] //[Guid("")]
    public class SettingsPage : PageData
    {

        [Editable(true)]
        [Display(
            Name = "Söksida",
            Description = "Här pekar ni ut söksidan.",
            GroupName = SystemTabNames.Content)]
        public virtual PageReference SearchPage { get; set; }


        [Editable(true)]
        [Display(
            Name = "Menyroot",
            Description = "Här pekar ni ut vilken sida som är rooten för menyn.",
            GroupName = SystemTabNames.Content)]
        public virtual PageReference MenuRoot { get; set; }


        [Editable(true)]
        [Display(
            Name = "Länkar i sidhuvud.",
            Description = "Här skapas länkar länkar som ska visas i sidhuvudet.",
            GroupName = SystemTabNames.Content)]
        public virtual LinkItemCollection HeaderLinks { get; set; }

        [Editable(true)]
        [Display(
            Name = "Länkar i sidfoten",
            Description = "Här skapas länkar som ska visas i sidfoten.",
            GroupName = SystemTabNames.Content)]
        public virtual LinkItemCollection TopFooterLinks { get; set; }




        #region CookieNotice

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Rubrik när cookies är aktiverade",
            Description = "Välj vilken rubrik som ska visas när cookies är aktiverade.",
            GroupName = Tabs.Cookies)]
        public virtual string CookiesActiveHeading { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Rubrik när cookies är inaktiverade",
            Description = "Välj vilken rubrik som ska visas när cookies är inaktiverade.",
            GroupName = Tabs.Cookies)]
        public virtual string CookiesDisabledHeading { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Text när cookies är aktiverade",
            Description = "Välj text som ska visas när cookies är aktiverade.",
            GroupName = Tabs.Cookies)]
        public virtual string CookiesActiveMessage { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Text när cookies är inaktiverade",
            Description = "Välj text som ska visas när cookies är inaktiverade.",
            GroupName = Tabs.Cookies)]
        public virtual string CookiesDisabledMessage { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Länktext",
            Description = "Text som ska visas i länken tex 'Läs mer'",
            GroupName = Tabs.Cookies)]
        public virtual string CookieNoticeReadMoreText { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [BackingType(typeof(PropertyUrl))]
        [Display(
            Name = "Länkurl",
            Description = "Peka ut url.",
            GroupName = Tabs.Cookies)]
        public virtual Url CookieNoticeReadMoreURL { get; set; }

        #endregion
    }
}
