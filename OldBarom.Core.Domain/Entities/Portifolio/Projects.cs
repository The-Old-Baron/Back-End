using OldBarom.Infra.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Entities.Portifolio
{
    [Table("Projects", Schema = "Portifolio")]
    public class Projects
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public string? Tags { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLocked { get; set; }
        public string Version { get; set; }
        public string ApplicationUserIdOwner { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public Dictionary<int,ProjectInformations> ProjectInformations { get; set; }
        
        
    }
}
