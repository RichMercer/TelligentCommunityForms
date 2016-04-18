using System.Collections.Generic;
using Telligent.Evolution.Extensibility;
using Telligent.Evolution.Extensibility.Api.Version1;
using TEApi = Telligent.Evolution.Extensibility.Api.Version1.PublicApi;

namespace TelligentCommunityForms.PublicApi
{
    public class FormUrls
    {
        public string Forms()
        {
            // TODO: Replace hard coded group id
            return Apis.Get<IUrl>().BuildUrl("forms.list", 1);
        }

        public string New()
        {
            // TODO: Replace hard coded group id
            return Apis.Get<IUrl>().BuildUrl("forms.new", 1);
        }

        public string Edit(int formId)
        {
            // TODO: Replace hard coded entity
            var form = new Form
            {
                Title = "New Form",
                Body = "Test entity",
                Id = formId,
                GroupId = 1
            };

            return Apis.Get<IUrl>().BuildUrl("forms.edit", form.GroupId, new Dictionary<string, string>
                {
                    { "id", form.Id.ToString() }
                });
        }

        public string Form(int formId)
        {
            // TODO: Replace hard coded entity
            var form = new Form
            {
                Title = "New Form",
                Body = "Test entity",
                Id = formId,
                GroupId = 1
            };

            return Apis.Get<IUrl>().BuildUrl("forms.view", form.GroupId, new Dictionary<string, string>
                {
                    { "id", form.Id.ToString() }
                });
        }
    }
}
