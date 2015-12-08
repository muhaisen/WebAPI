using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EllevioCore.EPiServerCMS.CustomizationClasses.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayRegistryInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                // Register Display Options
                var options = ServiceLocator.Current.GetInstance<EPiServer.Web.DisplayOptions>();
                options
                    .Add("full", "/displayoptions/full", Global.ContentAreaTags.FullWidth, "", "epi-icon__layout--full")
                    .Add("wide", "/displayoptions/wide", Global.ContentAreaTags.HalfWidth, "", "epi-icon__layout--two-thirds")
                    .Add("narrow", "/displayoptions/narrow", Global.ContentAreaTags.OneFourthWidth, "", "epi-icon__layout--one-third");


            }
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context) { }
    }
}
