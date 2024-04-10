using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using OldBarom.Core.Domain.Validation;
namespace OldBarom.Core.Domain.Entities.Portifolio
{
    [Table("Projects", Schema = "Portifolio")]
    public class Projects
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public string? Tags { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLocked { get; set; }
        public string? Version { get; set; }
        public string? ApplicationUserIdOwner { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public Dictionary<int,ProjectInformations>? ProjectInformations { get; set; }
        
        public Projects(string title, string description, string url, string image, string tags, bool isFavorite, bool isRead, DateTime createdAt, DateTime updatedAt, bool isLocked, string version, string applicationUserIdOwner)
        {
            Title = title;
            Description = description;
            Url = url;
            Image = image;
            Tags = tags;
            IsFavorite = isFavorite;
            IsRead = isRead;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsLocked = isLocked;
            Version = version;
            ApplicationUserIdOwner = applicationUserIdOwner;
            DomainValidation(title, description, url, image, tags);
        }
        protected Projects() { }
        private void DomainValidation(string title, string description, string url, string image, string tags)
        {
            if(title.Length < 3 || title.Length > 50)
            {
                throw new DomainExceptionValidation("Title must be between 3 and 50 characters");
            }
            if(description.Length > 100)
            {
                throw new DomainExceptionValidation("Description must be less than 100 characters");
            }
            if(url.Length > 100)
            {
                throw new DomainExceptionValidation("Url must be less than 100 characters");
            }
            if(image.Length > 100)
            {
                throw new DomainExceptionValidation("Image must be less than 100 characters");
            }
            if(tags.Length > 100)
            {
                throw new DomainExceptionValidation("Tags must be less than 100 characters");
            }
        }
    }
}
