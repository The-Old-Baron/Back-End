using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Model.Base
{
    [Table("Keywords", Schema = "BSYS")]
    public class Keywords
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Keywords()
        {
        }
    }
}