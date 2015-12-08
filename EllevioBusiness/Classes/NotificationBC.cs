using EllevioCore.Ellevio;
using EllevioCore.Ellevio.Entities;
using EllevioCore.EPiServerCMS.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllevioBusiness.Classes
{
    public class NotificationBC
    {

        public CookieNoticeBE GetCookieNoticeInformation(string lang)
        {
            CookieNoticeBE cookieNoticeBE = new CookieNoticeBE();
            try
            {
                SettingsPage settingsPage = new CommonBusiness().GetSettingsPage(lang);
                cookieNoticeBE.CookiesActiveHeading = settingsPage.CookiesActiveHeading;
                cookieNoticeBE.CookiesDisabledHeading = settingsPage.CookiesDisabledHeading;
                cookieNoticeBE.CookiesActiveMessage = settingsPage.CookiesActiveMessage;
                cookieNoticeBE.CookiesDisabledMessage = settingsPage.CookiesDisabledMessage;
                cookieNoticeBE.ReadMoreText = settingsPage.CookieNoticeReadMoreText;
                cookieNoticeBE.ReadMoreURL = new CommonBusiness().GetFriendlyURL(settingsPage.CookieNoticeReadMoreURL.Uri.OriginalString);
            }
            catch (Exception ex)
            {
                //LOG HERE
            }
            return cookieNoticeBE;
        }
      
    }
}
