using OldBarom.Core.Domain.Validation;
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

        public Countries(string name, string iSO3, string numericCode, string iSO2, string currency, string currencyName, int regionId)
        {
            Name = name;
            ISO3 = iSO3;
            NumericCode = numericCode;
            ISO2 = iSO2;
            Currency = currency;
            CurrencyName = currencyName;
            RegionId = regionId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ValidateDomain();
        }

        protected Countries()
        {
        }
        private void ValidateDomain()
        {
            if (string.IsNullOrEmpty(Name))
                throw new DomainExceptionValidation("Name is required");
            if (string.IsNullOrEmpty(ISO3))
                throw new DomainExceptionValidation("ISO3 is required");
            if (string.IsNullOrEmpty(NumericCode))
                throw new DomainExceptionValidation("NumericCode is required");
            if (string.IsNullOrEmpty(ISO2))
                throw new DomainExceptionValidation("ISO2 is required");
            if (string.IsNullOrEmpty(Currency))
                throw new DomainExceptionValidation("Currency is required");
            if (string.IsNullOrEmpty(CurrencyName))
                throw new DomainExceptionValidation("CurrencyName is required");
            if (RegionId == 0)
                throw new DomainExceptionValidation("RegionId is required");
        }
    }
}
