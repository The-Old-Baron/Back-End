using OldBarom.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Entities.Systempunk
{
    [Table("History", Schema="SYST")]
    public class History
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public List<string> keywords { get; set; }
        public List<int> tags { get; set; }
        public Guid UserOwnerId { get; set; }
        public Guid LastEditorID { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EditedTime { get; set; }
        public string Content {  get; set; }
        public virtual List<Tag> Tags { get; set; }

        public History(int id, string name, string description, List<string> keywords,  Guid userOwnerId, Guid lastEditorID, DateTime publishDate, DateTime editedTime, string content, List<Tag> tags)
        {
            ValidateDomain(name, description, keywords, userOwnerId, lastEditorID, content, tags);
            Id = id;
            PublishDate = publishDate;
            EditedTime = editedTime;
        }
        private void ValidateDomain(string Name, string Description, List<string> keywords, Guid userOwnerID, Guid lastEditorID, string content, List<Tag> tags)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "Invalid - input is required");
            DomainExceptionValidation.When(Name.Length < 3, "Invalid - input is too short");
            DomainExceptionValidation.When(string.IsNullOrEmpty(Description), "Invalid - input is required");
            DomainExceptionValidation.When(Description.Length < 3, "Invalid - input is too short");
            DomainExceptionValidation.When(keywords.Count < 1, "Invalid - input is required");
            DomainExceptionValidation.When(userOwnerID == null, "Invalid - input is required");
            DomainExceptionValidation.When(lastEditorID == null, "Invalid - input is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(content), "Invalid - input is required");
            DomainExceptionValidation.When(content.Length < 3, "Invalid - input is too short");
            DomainExceptionValidation.When(tags.Count < 1, "Invalid - input is required");

            this.Name = Name;
            this.Description = Description;
            this.keywords = keywords;
            UserOwnerId = userOwnerID;
            LastEditorID = lastEditorID;
            PublishDate = DateTime.Now;
            EditedTime = DateTime.Now;
            Content = content;
            Tags = tags;
        }

    }
}
