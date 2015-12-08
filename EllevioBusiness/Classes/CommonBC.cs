using EllevioDAL.Classes;
using EllevioCore.EPiServerCMS.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EllevioBusiness.Classes
{
    public class CommonBusiness
    {
        public SettingsPage GetSettingsPage(string language)
        {
            return new CommonDAL().GetSettingsPage(language);
        }

        public SearchPage GetSearchPage(string language)
        {
            return new CommonDAL().GetSearchPage(language);
        }

        public StartPage GetStartPage(string language)
        {
            return new CommonDAL().GetStartPage(language);
        }

        public IContent GetIContentFromPageReference(string language, PageReference pageRef)
        {
            return new CommonDAL().GetIContentFromPageReference(language, pageRef);
        }

        public PageReference GetMenuRoot()
        {
            SettingsPage settingsPage = GetSettingsPage("");
            return settingsPage.MenuRoot;
        }


        public bool IsURLExternal(string url)
        {
            try
            {
                int result = Uri.Compare(new Uri(url), EPiServer.Web.SiteDefinition.Current.SiteUrl, UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture);
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Converts an unformatted URL and returns it as a friendly URL
        /// </summary>
        /// <param name="PageLink"></param>
        /// <param name="URL"></param>
        /// <returns></returns>
        public string GetFriendlyURL(string URL)
        {
            var url = new UrlBuilder(URL);
            try
            {
                EPiServer.Global.UrlRewriteProvider.ConvertToExternal(url, null, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //Log here
            }
            return url.Uri.IsAbsoluteUri ? url.Uri.AbsoluteUri : url.Uri.OriginalString;
        }

        public string GetFriendlyURL(IContent content, string lang)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var url = "";
            if (string.IsNullOrEmpty(lang))
            {
                url = urlResolver.GetUrl(content.ContentLink);
            }
            else
            {
                url = urlResolver.GetUrl(content.ContentLink, lang);
            }
            return url;
        }

        public string GetCurrentLanguageCode()
        {
            return EPiServer.Globalization.ContentLanguage.PreferredCulture.Name;
        }


        public string GetSearchURL(string lang)
        {
            return new CommonBusiness().GetSearchPage(lang).LinkURL;
        }


        private static string GetExternalUrl(IContent content)
        {
            try
            {
                if (content != null)
                {
                    var internalUrl = UrlResolver.Current.GetUrl(content.ContentLink, null, new VirtualPathArguments() { ContextMode = ContextMode.Default });

                    var url = new UrlBuilder(internalUrl);
                    Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.Encoding.UTF8);

                    //var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());
                    string externalUrl = HttpContext.Current == null ? UriSupport.AbsoluteUrlBySettings(url.ToString())
                    : HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + url;

                    return externalUrl;
                }
            }

            catch (Exception ex)
            {
                return null;
            }

            return String.Empty;


        }
    }
}
