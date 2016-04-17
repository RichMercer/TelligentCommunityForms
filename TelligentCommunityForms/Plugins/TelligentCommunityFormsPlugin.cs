using System;
using System.Collections.Generic;
using Telligent.Evolution.Extensibility;
using Telligent.Evolution.Extensibility.Api.Version1;
using Telligent.Evolution.Extensibility.Content.Version1;
using Telligent.Evolution.Extensibility.UI.Version1;
using Telligent.Evolution.Extensibility.Urls.Version1;
using Telligent.Evolution.Extensibility.Version1;
using TelligentCommunityForms.Plugins;
using INavigableApplicationType = Telligent.Evolution.Components.INavigableApplicationType;

namespace TelligentCommunityForms
{
    public class TelligentCommunityFormsPlugin : INavigableApplicationType, IApplicationNavigable, ITranslatablePlugin, IPluginGroup, IApplicationType
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

        #region IApplicationType Members

        public IEnumerable<Type> Plugins => new List<Type>
        {
            typeof(FormsContainerPanels),
            typeof(FormsExtensionsPlugin),
            typeof(FormsUrlExtensionsPlugin)
        };

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

        public void RegisterUrls(IUrlController controller)
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
            <contentFragment type=""Telligent.Evolution.ScriptedContentFragments.ScriptedContentFragment, Telligent.Evolution.ScriptedContentFragments::e7f32628f5e24f59ad25cf309d9178bf"" showHeader=""False"" cssClassAddition=""no-wrapper with-spacing responsive-1"" isLocked=""False"" configuration=""fragmentHeader=%24%7Bresource%3ALeaderboard_Name%7D&amp;visible=False"" />
            <contentFragment type=""Telligent.Evolution.ScriptedContentFragments.ScriptedContentFragment, Telligent.Evolution.ScriptedContentFragments::f68e8c5ecc7c42bd950b83b3967abd61"" showHeader=""True"" cssClassAddition=""top-border with-spacing with-header responsive-1"" isLocked=""False"" configuration=""fragmentHeader=%24%7Bresource%3ALeaderboardList_Name%7D&amp;group=IncludeSubGroups%3D%2520False%26Group%3D0%26GroupPath%3D&amp;pageSize=10&amp;leadersSize=5"" />
          </contentFragments>
        </region>
      </regions>
      <contentFragmentTabs />
    </contentFragmentPage>"
            });

            controller.AddPage("forms.view", "", null, null, "forms-view", new PageDefinitionOptions
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
            <contentFragment type=""Telligent.Evolution.ScriptedContentFragments.ScriptedContentFragment, Telligent.Evolution.ScriptedContentFragments::e7f32628f5e24f59ad25cf309d9178bf"" showHeader=""False"" cssClassAddition=""no-wrapper with-spacing responsive-1"" isLocked=""False"" configuration=""fragmentHeader=%24%7Bresource%3ALeaderboard_Name%7D&amp;visible=False"" />
            <contentFragment type=""Telligent.Evolution.ScriptedContentFragments.ScriptedContentFragment, Telligent.Evolution.ScriptedContentFragments::f68e8c5ecc7c42bd950b83b3967abd61"" showHeader=""True"" cssClassAddition=""top-border with-spacing with-header responsive-1"" isLocked=""False"" configuration=""fragmentHeader=%24%7Bresource%3ALeaderboardList_Name%7D&amp;group=IncludeSubGroups%3D%2520False%26Group%3D0%26GroupPath%3D&amp;pageSize=10&amp;leadersSize=5"" />
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

        public Translation[] DefaultTranslations
        {
            get
            {
                var t = new Translation("en-us");

                t.Set("application-plugin-name", "Telligent Community Forms & Surveys");
                t.Set("application-plugin-desc", "Enables the creation of forms and surveys in Telligent Community.");
                t.Set("application_type_name", "Forms & Surveys");
                t.Set("page-forms-list", "Forms & Surveys");
                t.Set("page-forms-list-description", "The homepage for viewing Forms and Surveys");

                return new[] { t };
            }
        }

        #endregion

    }
}
