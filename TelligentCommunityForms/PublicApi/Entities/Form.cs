using System;
using Telligent.Evolution.Extensibility;
using Telligent.Evolution.Extensibility.Api.Entities.Version1;
using Telligent.Evolution.Extensibility.Api.Version1;
using Telligent.Evolution.Extensibility.Content.Version1;

namespace TelligentCommunityForms
{
    public class Form : ApiEntity, IContent, IApplication
    {
        IApplication IContent.Application => Apis.Get<IGroups>().GetRootGroup();

        public string AvatarUrl => null;

        public Guid ContentTypeId => Constants.ContentTypeId;

        public string HtmlDescription(string target)
        {
            return Body;
        }

        public string HtmlName(string target)
        {
            return Title;
        }

        public string Url => $"/{Constants.PathDelimiter}/{ApplicationKey}";

        public Guid ContentId { get; set; }
        
        public int Id { get; set; }

        public string ApplicationKey { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Summary { get; set; }

        public int GroupId { get; set; }

        public Guid ApplicationId { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsIndexed { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ApplicationTypeId => Constants.ApplicationTypeId;

        public IContainer Container => Apis.Get<IGroups>().GetRootGroup();
    }
}
