using OldBarom.Core.Domain.Validation;
using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OldBarom.Core.Domain.Entities.TeamController
{
    [Table("Teams", Schema = "Team")]
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Type { get; set; }
        [Required]
        [ForeignKey("TeamCategories")]
        public int TeamCategoryID { get; set; }
        public virtual TeamCategories? TeamCategory { get;set; }
        
        public string? Tags { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}
        public string? UserOwner_ID { get; set; }
        public virtual ApplicationUser? UserOwner { get; set; }

        public Team(string name, string description, string type, int teamCategoryID, string tags, DateTime createdDate, DateTime lastUpdatedDate, string userOwner_ID)
        {
            Name = name;
            Description = description;
            Type = type;
            TeamCategoryID = teamCategoryID;
            Tags = tags;
            CreatedDate = createdDate;
            LastUpdatedDate = lastUpdatedDate;
            UserOwner_ID = userOwner_ID;
            DomainValidation(name, description, type, tags);
        }
        protected Team() { }
        private void DomainValidation(string name, string description, string type, string tags)
        {
            if(name.Length < 3 || name.Length > 50)
            {
                throw new DomainExceptionValidation("Name must be between 3 and 50 characters");
            }
            if(description.Length > 500)
            {
                throw new DomainExceptionValidation("Description must be less than 500 characters");
            }
            if(type.Length > 50)
            {
                throw new DomainExceptionValidation("Type must be less than 50 characters");
            }
            if(tags.Length > 100)
            {
                throw new DomainExceptionValidation("Tags must be less than 100 characters");
            }
        }
    }
}
