using Telligent.Evolution.Extensibility.Api.Entities.Version1;
using Telligent.Evolution.Extensibility.UI.Version1;
using TelligentCommunityForms.PublicApi;

namespace TelligentCommunityForms.Plugins
{
    public class FormsExtensionsPlugin : IScriptedContentFragmentExtension
    {
        public string Description => "Provides widget extensions for Forms and Surveys.";

        public object Extension => new Forms();

        public string ExtensionName => "forms_v1_form";

        public string Name => "Forms Widget Extensions";

        public void Initialize()
        {
        }
    }
}
