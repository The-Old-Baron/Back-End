using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OldBarom.Core.Domain.Model.Base
{
    [Table("Tags", Schema = "BSYS")]
    public class Tags
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public Tags()
        {
        }
    }
}
