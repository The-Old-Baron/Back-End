using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.Systempunk
{
    [Table("Tags", Schema = "SYST")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Tag(string name, string Description)
        {
            ValidateDomain(name, Description);
        }
        public Tag(int id, string name, string Description)
        {
            ValidateDomain(name, Description);
            Id = id;
        }
        private void ValidateDomain(string Name, string Description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "Invalid - input is required");
            DomainExceptionValidation.When(Name.Length < 3, "Invalid - input is too short");
            DomainExceptionValidation.When(string.IsNullOrEmpty(Description), "Invalid - input is required");
            DomainExceptionValidation.When(Description.Length < 3, "Invalid - input is too short");

            Name = Name;
            this.Description = Description;
        }
    }
}
