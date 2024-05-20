using OldBarom.Core.Domain.Entities.Systempunk;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OldBarom.Core.Application.DTOs.Systempunk
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(3)]
        [MaxLength(500)]
        [DisplayName("Description")]
        public string Description {  get; set; }
        [DisplayName("Keyword List")]
        public List<string> Keywords { get; set; }
        [Required(ErrorMessage = "The UserOwnerID is Required")]
        [DisplayName("User Owner ID")]
        public Guid UserOwnerID { get; set; }
        [DisplayName("Last Editor ID")]
        public Guid LastEditorID { get; set; }
        [DisplayName("Published Date")]
        public DateTime PublishDate { get; set; }
        [Required(ErrorMessage = "The EditedTime is Required")]
        [DisplayName("Edited Date")]
        public DateTime EditedTime { get; set; }
        [Required(ErrorMessage = "The Content is Required")]
        [DisplayName("History")]
        public string Content { get; set; }
        [DisplayName("Tag List")]
        [JsonIgnore]
        public List<Tag> Tags { get; set; }
        [Required(ErrorMessage = "Tag List Is Necessary")]
        [DisplayName("Tag ID")]
        public List<int> TagsId { get; set; }

    }
}
