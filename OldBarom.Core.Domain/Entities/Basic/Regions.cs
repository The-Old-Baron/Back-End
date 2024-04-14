
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OldBarom.Core.Domain.Validation;
namespace OldBarom.Core.Domain.Entities.Basic
{
    [Table("Regions", Schema = "Basic")]
    public class Regions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string? Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
        protected Regions()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public Regions(string name, string code)
        {
            Name = name;
            Code = code;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            DomainValidation();
        }
        private void DomainValidation()
        {
            if (string.IsNullOrEmpty(Name))
                throw new DomainExceptionValidation("Name is required");
            if (string.IsNullOrEmpty(Code))
                throw new DomainExceptionValidation("Code is required");
        }
    }
}
