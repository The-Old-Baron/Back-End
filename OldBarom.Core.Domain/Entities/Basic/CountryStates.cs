using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OldBarom.Core.Domain.Validation;
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
        protected CountryStates()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public CountryStates(int countryId, string name)
        {
            Name = name;
            CountryId = countryId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            DomainValidation();
        }
        private void DomainValidation()
        {
            if (string.IsNullOrEmpty(Name))
                throw new DomainExceptionValidation("Name is required");
            if (CountryId <= 0)
                throw new DomainExceptionValidation("Country is required");
        }
    }
}
