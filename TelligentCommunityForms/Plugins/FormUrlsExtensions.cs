﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telligent.Evolution.Extensibility.UI.Version1;
using TelligentCommunityForms.PublicApi;

namespace TelligentCommunityForms.Plugins
{
    public class FormsUrlExtensionsPlugin : IScriptedContentFragmentExtension
    {
        public string Description => "Provides widget extensions for Forms and Surveys URL's.";

        public object Extension => new FormUrls();

        public string ExtensionName => "forms_v1_formUrls";

        public string Name => "Forms URL Widget Extensions";

        public void Initialize()
        {
        }
    }
}
