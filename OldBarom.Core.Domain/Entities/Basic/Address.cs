using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OldBarom.Core.Domain.Entities.Basic
{
    [Table  ("Address", Schema = "Basic")]
    public class Address
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string? Street { get; private set; }
        [Required]
        public int CityId { get; private set; }
        public virtual Cities? City { get; private set; }
        [Required]
        public string? ZipCode { get; private set; }

        
    }
}
