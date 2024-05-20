using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.DTOs.Systempunk
{
    public class TagDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(3)]
        [MaxLength(300)]
        [DisplayName("Description")]
        public string Description { get; set; }

    }
}
