using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.Basic
{
    [Table("Cities", Schema = "Basic")]
    public class Cities
    {
        
        [Key]
        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; private set; }
        [Required]
        [MaxLength(100)]
        public int StateId { get; private set; }
        public virtual CountryStates? State { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        
    }
}
