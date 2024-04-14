using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations;

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
        protected UserAddress() { }
        public UserAddress(string userID, Guid addressID)
        {
            UserID = userID;
            AddressID = addressID;
            DomainValidate();
        }
        private void DomainValidate()
        {
            if (string.IsNullOrEmpty(UserID))
                throw new Exception("UserID is required");
            if (AddressID == Guid.Empty)
                throw new Exception("AddressID is required");
        }
    }
}
