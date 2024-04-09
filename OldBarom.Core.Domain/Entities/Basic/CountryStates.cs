using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.Basic
{
    [Table("CountryStates", Schema = "Basic")]
    public class CountryStates
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; private set; }
        [Required]
        [MaxLength(100)]
        public int CountryId { get; private set; }
        public virtual Countries? Country { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
