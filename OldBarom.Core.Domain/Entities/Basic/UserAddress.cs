using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations;
using OldBarom.Core.Domain.Validation;
namespace OldBarom.Core.Domain.Entities.Basic
{
    public class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }
        [Required]
        public string? UserID { get; set; }
        [Required]
        public Guid AddressID { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual Address? Address { get; set; }

        public UserAddress(string userID, Guid addressID)
        {
            UserID = userID;
            AddressID = addressID;
            DomainValidation();
        }
        protected UserAddress()
        {
        }
        private void DomainValidation()
        {
            if (string.IsNullOrEmpty(UserID))
                throw new DomainExceptionValidation("UserID is required");
            if (AddressID == Guid.Empty)
                throw new DomainExceptionValidation("AddressID is required");
        }
    }
}
