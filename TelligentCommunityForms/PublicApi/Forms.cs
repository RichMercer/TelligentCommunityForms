using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telligent.Evolution.Extensibility.Api.Entities.Version1;

namespace TelligentCommunityForms.PublicApi
{
    public class Forms
    {
        public Guid ContentTypeId => Constants.ContentTypeId;

        //TODO: Replace with proper context lookup
        public Form Current => Get(1);

        public Form Get(int id)
        {
            return new Form
            {
                Title = "Test Form " + id,
                Body = "This is a hard coded survey loaded via the widget extensions. Please fix me.",
                Id = id,
                GroupId = 1
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
