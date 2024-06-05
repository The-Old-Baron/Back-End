using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Model.Base
{
    [Table("KeywordType", Schema = "BSYS")]
    public class KeywordType
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

    }
}
