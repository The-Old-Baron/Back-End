using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Model.Base
{
    [Table("Keywords", Schema = "BSYS")]
    public class Keywords
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int KeywordTypeID { get; set; }
<<<<<<< HEAD
        
        public Keywords()
        {
        }
=======
        public virtual required KeywordType KeywordType { get; set; }
       
>>>>>>> d0b5c26ee7ecf969955d99a07e67b7cd2d66d3f2
    }
}
