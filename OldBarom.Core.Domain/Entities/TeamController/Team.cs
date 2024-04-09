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
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [ForeignKey("TeamCategories")]
        public int TeamCategoryID { get; set; }
        public virtual TeamCategories TeamCategory { get;set; }
        
        public string Tags { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}
        public string UserOwner_ID { get; set; }
        public virtual ApplicationUser UserOwner { get; set; }

        
    }
}
