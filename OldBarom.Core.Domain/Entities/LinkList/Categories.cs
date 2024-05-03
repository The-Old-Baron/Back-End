using OldBarom.Core.Domain.Validation;
using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.LinkList
{
    [Table("Categories", Schema = "LinkList")]

    public class Categories
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public string? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        
        protected Categories()
        {
        }
        public Categories(string name, string description, string applicationUserId)
        {
            Name = name;
            Description = description;
            ApplicationUserId = applicationUserId;
            Validate(name, description, applicationUserId);
        }
        private void Validate(string name, string description, string applicationUserId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name. Name must have at least 3 characters");
            DomainExceptionValidation.When(name.Length > 50, "Invalid Name. Name must have a maximum of 50 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description. Description is required");
            DomainExceptionValidation.When(description.Length > 100, "Invalid Description. Description must have a maximum of 100 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(applicationUserId), "Invalid User ID. User ID is required");
        }
    }
}
