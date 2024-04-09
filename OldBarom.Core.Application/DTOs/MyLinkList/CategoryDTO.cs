using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations;

namespace OldBarom.Core.Application.DTOs.MyLinkList
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
