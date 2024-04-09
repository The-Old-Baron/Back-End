using System.ComponentModel.DataAnnotations.Schema;
using OldBarom.Infra.Data.Identity;

namespace OldBarom.Core.Domain.Entities.LinkList
{
    [Table("Links", Schema = "LinkList")]
    public class Links
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public string? Tags { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsRead { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Categories? Category { get; set; }
        public bool IsLocked { get; set; }
        public string? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

    }
}
