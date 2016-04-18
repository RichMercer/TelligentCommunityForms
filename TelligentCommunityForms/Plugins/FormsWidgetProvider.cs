using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telligent.Evolution.Extensibility.UI.Version1;

namespace TelligentCommunityForms
{
    public class FormsWidgetProvider : IScriptedContentFragmentFactoryDefaultProvider
    {
        static readonly Guid FactoryDefaultId = new Guid("f41af13823764dc39122cc1bbff86597");

        #region IPlugin Members

        public string Name => "Forms Widgets Provider";

        public string Description => "Provides widgets for the Forms and Surveys Application.";

        public void Initialize()
        {
        }

        #endregion

        #region IScriptedContentFragmentFactoryDefaultProvider Members

        public Guid ScriptedContentFragmentFactoryDefaultIdentifier => FactoryDefaultId;

        #endregion
    }
}
