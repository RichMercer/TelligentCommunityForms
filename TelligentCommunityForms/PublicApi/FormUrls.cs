using System.Collections.Generic;
using TEApi = Telligent.Evolution.Extensibility.Api.Version1.PublicApi;

namespace TelligentCommunityForms.PublicApi
{
    public class FormUrls
    {
        public string Forms()
        {
            return TEApi.Url.BuildUrl("forms.list", 1);
        }

        public string Form(int formId)
        {
            var form = new Form
            {
                Title = "New Form",
                Body = "Test entity",
                Id = formId,
                GroupId = 1
            };

            return TEApi.Url.BuildUrl("forms.view", form.GroupId, new Dictionary<string, string>
                {
                    { "id", form.Id.ToString() }
                });
        }
    }
}
