using System;
using System.Collections.Generic;
using Telligent.Evolution.Extensibility;
using Telligent.Evolution.Extensibility.Api.Version1;
using Telligent.Evolution.Extensibility.Content.Version1;
using Telligent.Evolution.Extensibility.Urls.Version1;
using Telligent.Evolution.Extensibility.Version1;
using TelligentCommunityForms.Plugins;

namespace TelligentCommunityForms
{
    public class TelligentCommunityFormsPlugin : INavigableApplicationType, IApplicationNavigable, ITranslatablePlugin, IPluginGroup, IContentType
    {
        private ITranslatablePluginController _translationController;

        #region IPlugin Members

        public string Name => _translationController.GetLanguageResourceValue("application-plugin-name");

        public string Description => _translationController.GetLanguageResourceValue("application-plugin-desc");

        public void Initialize()
        {
        }

        #endregion

        #region INavigableApplicationType Members

        public string PathDelimiter => Constants.PathDelimiter;

        #endregion

        public IEnumerable<Type> Plugins => new List<Type>
        {
            typeof(FormsContainerPanels),
            typeof(FormsExtensionsPlugin),
            typeof(FormsUrlExtensionsPlugin)
        };

        #region IApplicationType Members

        public string ApplicationTypeName => _translationController.GetLanguageResourceValue("application_type_name");

        public Guid[] ContainerTypes => new[] { Apis.Get<IGroups>().ApplicationTypeId };

        public IApplication Get(Guid applicationId)
        {
            var form = new Form
            {
                Id = 1,
                Title = "Knowledge Base",
                ApplicationId = applicationId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                GroupId = 1
            };

            return form;
        }

        public void AttachChangeEvents(IApplicationStateChanges stateChanges)
        {
        }

        #endregion

        #region IApplicationNavigable Members

        public Guid ApplicationTypeId => Constants.ApplicationTypeId;

        void IApplicationNavigable.RegisterUrls(IUrlController controller)
        {
            controller.AddPage("forms.list", "", null, null, "forms-list", new PageDefinitionOptions
            {
                ParseContext = null,
                HasApplicationContext = false,
                TitleFunction = () => _translationController.GetLanguageResourceValue("page-forms-list"),
                DescriptionFunction = () => _translationController.GetLanguageResourceValue("page-forms-list-description"),
                DefaultPageXml =
    @"<contentFragmentPage pageName=""forms-list"" isCustom=""false"" layout=""Content"" themeType=""c6108064-af65-11dd-b074-de1a56d89593"">
      <regions>
        <region regionName=""Content"">
          <contentFragments>
          </contentFragments>
        </region>
      </regions>
      <contentFragmentTabs />
    </contentFragmentPage>"
            });

            controller.AddPage("forms.view", "{id}", null, null, "forms-view", new PageDefinitionOptions
            {
                ParseContext = null,
                HasApplicationContext = false,
                TitleFunction = () => _translationController.GetLanguageResourceValue("page-forms-list"),
                DescriptionFunction = () => _translationController.GetLanguageResourceValue("page-forms-list-description"),
                DefaultPageXml =
    @"<contentFragmentPage pageName=""forms-list"" isCustom=""false"" layout=""Content"" themeType=""c6108064-af65-11dd-b074-de1a56d89593"">
      <regions>
        <region regionName=""Content"">
          <contentFragments>
          </contentFragments>
        </region>
      </regions>
      <contentFragmentTabs />
    </contentFragmentPage>"
            });
        }

        #endregion

        #region ITranslatablePlugin Members

        public void SetController(ITranslatablePluginController controller)
        {
            _translationController = controller;
        }

        IContent IContentType.Get(Guid contentId)
        {
            var form = new Form
            {
                Id = 1,
                Title = "Knowledge Base",
                ApplicationId = contentId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                GroupId = 1
            };

            return form;
        }

        public void AttachChangeEvents(IContentStateChanges stateChanges)
        {
        }

        public Translation[] DefaultTranslations
        {
            get
            {
                var t = new Translation("en-us");

                t.Set("application-plugin-name", "Forms & Surveys");
                t.Set("application-plugin-desc", "Enables the creation of forms and surveys in Telligent Community.");
                t.Set("application_type_name", "Forms & Surveys");
                t.Set("page-forms-list", "Forms & Surveys");
                t.Set("page-forms-list-description", "The homepage for viewing Forms and Surveys");

                return new[] { t };
            }
        }

        public string ContentTypeName => _translationController.GetLanguageResourceValue("application_type_name");

        public Guid ContentTypeId => Constants.ApplicationTypeId;

        public Guid[] ApplicationTypes => new[] { ApplicationTypeId };

        #endregion
    }
}
