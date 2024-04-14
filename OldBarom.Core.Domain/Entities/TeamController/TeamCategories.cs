using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.TeamController
{
    [Table("TeamCategories", Schema = "Team")]
    public class TeamCategories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Categorie { get; set; }
    }
}
