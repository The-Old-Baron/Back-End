using OldBarom.Infra.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Entities.Basic
{
    public class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public Guid AddressID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Address Address { get; set; }
    }
}
