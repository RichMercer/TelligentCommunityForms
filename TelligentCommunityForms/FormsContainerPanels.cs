using System;
using System.Collections.Specialized;
using Telligent.Evolution.Extensibility;
using Telligent.Evolution.Extensibility.Administration.Version1;
using Telligent.Evolution.Extensibility.Api.Entities.Version1;
using Telligent.Evolution.Extensibility.Api.Version1;
using Telligent.Evolution.Extensibility.UI.Version1;
using Telligent.Evolution.Extensibility.Version1;

namespace TelligentCommunityForms
{
    public class FormsContainerPanels : IContainerPanel, IScriptablePlugin, ITranslatablePlugin
    {
        static readonly Guid FactoryDefaultId = new Guid("d519f5278af744b4a5c91fcfd94f0c5c");
        static readonly Guid FrontUiWidget = new Guid("8021ad46772944d8a59998fb5b49e5b6");

        IScriptedContentFragmentController _widgetController;
        ITranslatablePluginController _translation;

        #region IPlugin

        public string Name
        {
            get { return "Forms Panel"; }
        }

        public string Description
        {
            get { return "Panel provides managment of forms and surveys"; }
        }

        public void Initialize()
        {
            
        }
        #endregion

        #region IScriptablePlugin Members

        public void Register(IScriptedContentFragmentController controller)
        {
            _widgetController = controller;

            var widget = new ScriptedContentFragmentOptions(FrontUiWidget)
            {
                IsEditable = false,
                CanBeThemeVersioned = false,
                CanHaveHeader = false,
                CanHaveWrapperCss = false,
                CanReadPluginConfiguration = false
            };

            widget.Extensions.Add(new PanelContext(_translation));

            controller.Register(widget);
        }

        #endregion

        #region ITranslatablePlugin

        Translation[] ITranslatablePlugin.DefaultTranslations
        {
            get
            {
                var enUs = new Translation("en-US");

                enUs.Set("Rank", "Rank");
                enUs.Set("Username", "Username");
                enUs.Set("DisplayName", "Display Name");
                enUs.Set("EmailAddress", "Email Address");
                enUs.Set("Points", "Points");

                return new Translation[] { enUs };
            }
        }

        void ITranslatablePlugin.SetController(ITranslatablePluginController controller)
        {
            _translation = controller;
        }
        #endregion

        #region IScriptedContentFragmentFactoryDefaultProvider Members

        public Guid ScriptedContentFragmentFactoryDefaultIdentifier
        {
            get { return FactoryDefaultId; }
        }

        #endregion

        #region IApplicationPanel Members

        Guid[] IContainerPanel.ContainerTypes
        {
            get { return new Guid[] { Apis.Get<IGroups>().ContainerTypeId }; }
        }

        bool IContainerPanel.HasAccess(int userId, Guid containerType, Guid containerId)
        {
            // TODO: Set some security here so only certain people can create forms.
            return true;
        }

        string IContainerPanel.GetViewHtml(Guid containerType, Guid containerId)
        {
            var context = new NameValueCollection();
            context["containerTypeId"] = containerType.ToString();
            context["containerId"] = containerId.ToString();
            context["applicationTypeId"] = containerType.ToString();
            context["applicationId"] = containerId.ToString();

            return _widgetController.RenderContent(FrontUiWidget, context);
        }

        #endregion

        #region IPanel Members

        public Guid PanelId
        {
            get { return FrontUiWidget; }
        }

        public string GetPanelName(Guid containerType, Guid containerId)
        {
            return _widgetController.GetMetadata(FrontUiWidget).Name;
        }

        public string GetPanelDescription(Guid containerType, Guid containerId)
        {
            return _widgetController.GetMetadata(FrontUiWidget).Description;
        }

        public int? DisplayOrder
        {
            get { return 1500; }
        }

        public bool IsCacheable
        {
            get { return _widgetController.GetMetadata(FrontUiWidget).IsCacheable; }
        }

        public bool VaryCacheByUser
        {
            get { return _widgetController.GetMetadata(FrontUiWidget).VaryCacheByUser; }
        }

        public string CssClass
        {
            get { return _widgetController.GetMetadata(FrontUiWidget).CssClass; }
        }

        #endregion

        #region Helpers

        public class PanelContext : IContextualScriptedContentFragmentExtension
        {
            ITranslatablePluginController _translation;

            public PanelContext(ITranslatablePluginController translation)
            {
                _translation = translation;
            }

            public string ExtensionName
            {
                get { return "context"; }
            }

            public object GetExtension(NameValueCollection context)
            {
                Guid containerId, containerTypeId;

                if (!Guid.TryParse(context["containerTypeId"], out containerTypeId))
                    containerTypeId = Guid.Empty;

                if (!Guid.TryParse(context["containerId"], out containerId))
                    containerId = Guid.Empty;

                return new PanelContextApi(containerTypeId, containerId, _translation);
            }
        }

        public class PanelContextApi
        {
            ITranslatablePluginController _translation;

            public PanelContextApi(Guid containerTypeId, Guid containerId, ITranslatablePluginController translation)
            {
                _translation = translation;

                ContainerTypeId = containerTypeId;
                ContainerId = containerId;
            }

            public Guid ContainerTypeId
            {
                get;
                private set;
            }

            public Guid ContainerId
            {
                get;
                private set;
            }

            private Group _group;
            public Group Group
            {
                get
                {
                    if (_group == null)
                        _group = Apis.Get<IGroups>().Get(ContainerId);
                    return _group;
                }
            }

            public void HandleDownloadCsvRequest(int formId)
            {
                var httpContext = System.Web.HttpContext.Current;

                httpContext.Response.Clear();
                httpContext.Response.Cache.SetLastModified(DateTime.Now);
                httpContext.Response.ContentType = "text/csv; name=\"Leaders.csv\"";
                httpContext.Response.AddHeader("Content-disposition", "inline; filename=\"Leaders.csv\"");

                httpContext.Response.Write(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"\n",
                _translation.GetLanguageResourceValue("Rank"),
                _translation.GetLanguageResourceValue("Username"),
                _translation.GetLanguageResourceValue("DisplayName"),
                _translation.GetLanguageResourceValue("EmailAddress"),
                _translation.GetLanguageResourceValue("Points")));

                httpContext.Response.Write(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"\n",
                    1,
                    "RichMercer",
                    "Richard Mercer",
                    "rich@richmercer.com",
                    1234));

                httpContext.Response.End();
            }
        }
        #endregion

    }
}
