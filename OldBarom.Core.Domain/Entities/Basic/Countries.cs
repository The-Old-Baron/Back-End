using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.Basic
{
    [Table("Countries", Schema = "Basic")]
    public class Countries
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; private set; }
        [Required]
        [MaxLength(10)]
        public string? ISO3 { get; private set; }
        [Required]
        [MaxLength(10)]
        public string? NumericCode { get; private set; }
        [Required]
        [MaxLength(10)]
        public string? ISO2 { get; private set; }
        [Required]
        [MaxLength(10)]
        public string? Currency { get; private set; }
        [Required]
        [MaxLength(100)]
        public string? CurrencyName { get; private set; }
        [Required]
        [MaxLength(10)]
        public int RegionId { get; private set; }
        public virtual Regions? Regions { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
