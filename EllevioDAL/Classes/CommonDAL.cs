using EllevioCore.EPiServerCMS.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllevioDAL.Classes
{
    public class CommonDAL
    {
        public SettingsPage GetSettingsPage(string language)
        {
            try
            {
                var locator = ServiceLocator.Current.GetInstance<IContentRepository>();
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var settingsPageReference = contentRepository.Get<StartPage>(ContentReference.StartPage).SettingsPage;

                var startPage = contentRepository.Get<StartPage>(ContentReference.StartPage);
                if (startPage == null || startPage.SettingsPage == null)
                {
                    throw new ApplicationException(
                        "Settings page not configured. The website will not work until it has been configured.");
                }

                else if (string.IsNullOrEmpty(language))
                {
                    return contentRepository.Get<SettingsPage>(settingsPageReference, new LanguageSelectorFactory().MasterLanguage());
                }
                else
                {
                    return contentRepository.Get<SettingsPage>(settingsPageReference, new LanguageSelector(language));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SearchPage GetSearchPage(string language)
        {
            try
            {
                var locator = ServiceLocator.Current.GetInstance<IContentRepository>();
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                SettingsPage settingsPage = GetSettingsPage(language);
                if (settingsPage == null || settingsPage.SearchPage == null)
                {
                    throw new ApplicationException(
                        "Settings page or search page is not configured. The website will not work until it has been configured.");
                }
                else if (string.IsNullOrEmpty(language))
                {
                    return contentRepository.Get<SearchPage>(settingsPage.SearchPage, new LanguageSelectorFactory().MasterLanguage());
                }
                else
                {
                    return contentRepository.Get<SearchPage>(settingsPage.SearchPage, new LanguageSelector(language));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public StartPage GetStartPage(string language)
        {
            try
            {
                var locator = ServiceLocator.Current.GetInstance<IContentRepository>();
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var startPageReference = contentRepository.Get<StartPage>(ContentReference.StartPage);

                var startPage = contentRepository.Get<StartPage>(ContentReference.StartPage).LinkURL;

                if (startPage == null)
                {
                    throw new ApplicationException(
                        "Start page not configured. The website will not work until it has been configured.");
                }

                else if (string.IsNullOrEmpty(language))
                {

                    return contentRepository.Get<StartPage>(PageReference.StartPage);
                }
                else
                {
                    return contentRepository.Get<StartPage>(ContentReference.StartPage);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IContent GetIContentFromPageReference(string language, PageReference pageRef)
        {
            try
            {
                var locator = ServiceLocator.Current.GetInstance<IContentRepository>();

                if (locator == null)
                {
                    throw new ApplicationException(
                        "The page is not configured. The website will not work until it has been configured.");
                }

                else if (string.IsNullOrEmpty(language))
                {
                    IContent content = locator.Get<IContent>(pageRef, new LanguageSelectorFactory().MasterLanguage());
                    return content;
                }
                else
                {
                    IContent content = locator.Get<IContent>(pageRef, new LanguageSelector(language));
                    return content;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ContentData GetContentDataByReference(string language, ContentReference reference)
        {
            try
            {
                var locator = ServiceLocator.Current.GetInstance<IContentRepository>();
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                if (contentRepository == null)
                {
                    throw new ApplicationException(
                        "Content page is not configured. The website will not work until it has been configured.");
                }
                else if (string.IsNullOrEmpty(language))
                {
                    return contentRepository.Get<ContentData>(reference, new LanguageSelectorFactory().MasterLanguage());
                }
                else
                {
                    return contentRepository.Get<ContentData>(reference, new LanguageSelector(language));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
