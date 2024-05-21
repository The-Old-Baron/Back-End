using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Model.Base
{
    [Table("Tags", Schema = "BSYS")]
    public class Tags
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Tags()
        {
        }
    }
}