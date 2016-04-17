using System.Collections.Generic;
using TEApi = Telligent.Evolution.Extensibility.Api.Version1.PublicApi;

namespace TelligentCommunityForms.PublicApi
{
    public class FormUrls
    {
        public string Forms()
        {
            return TEApi.Url.BuildUrl("forms.list");
        }

        public string Form(int formId)
        {
            var form = new Form
            {
                Title = "New Form",
                Body = "Test entity."
            };
            return TEApi.Url.BuildUrl("forms.view", new Dictionary<string, string>
                {
                    { "AppKey", form.ApplicationKey }
                });
        }
    }
}
