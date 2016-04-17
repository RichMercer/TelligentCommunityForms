using Telligent.Evolution.Extensibility.Api.Entities.Version1;
using Telligent.Evolution.Extensibility.UI.Version1;

namespace TelligentCommunityForms.Plugins
{
    public class FormsExtensionsPlugin : IScriptedContentFragmentExtension
    {
        public string Description => "Provides widget extensions for Forms and Surveys.";

        public object Extension => new FormExtensions();

        public string ExtensionName => "forms_v1_form";

        public string Name => "Form Extensions";

        public void Initialize()
        {
        }
    }

    public class FormExtensions
    {
        public Form Get(int id)
        {
            return new Form
            {
                Title = "Test Form",
                Body = "This is a hard coded form loaded via the widget extensions. Please fix me.",
                Id = id
            };

        }

        public PagedList<Form> List()
        {
            return new PagedList<Form>
            {
                Get(1),
                Get(2),
                Get(3)
        };
        }
    }
}
