using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OldBarom.Core.Domain.Validation;
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
        protected Address()
        {
            Id = Guid.NewGuid();
        }
        public Address(string street, int cityId, string zip){
            Street = street;
            CityId = cityId;
            ZipCode = zip;
            DomainValidation();
        }
        private void DomainValidation()
        {
            if (string.IsNullOrEmpty(Street))
                throw new DomainExceptionValidation("Street is required");
            if (CityId <= 0)
                throw new DomainExceptionValidation("City is required");
            if (string.IsNullOrEmpty(ZipCode))
                throw new DomainExceptionValidation("ZipCode is required");
            
        }
    }
}
