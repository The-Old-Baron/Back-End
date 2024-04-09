using OldBarom.Core.Domain.Validation;
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
        
        public Cities()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public Cities(string name, int stateId)
        {
            Name = name;
            StateId = stateId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            DomainValidation();
        }
        private void DomainValidation()
        {
            if (string.IsNullOrEmpty(Name))
                throw new DomainExceptionValidation("Name is required");
            if (StateId <= 0)
                throw new DomainExceptionValidation("State is required");
        }
    }
}
