using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OldBarom.Core.Domain.Validation;
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

        public TeamCategories(string categorie)
        {
            Categorie = categorie;
        }
        protected TeamCategories() { }
        private void DomainValidation(string categorie)
        {
            if(categorie.Length < 3 || categorie.Length > 50)
            {
                throw new DomainExceptionValidation("Categorie must be between 3 and 50 characters");
            }
        }
    }
}
