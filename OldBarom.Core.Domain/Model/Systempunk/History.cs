using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OldBarom.Core.Domain.Model.Systempunk
{
    [Table("History", Schema = "SYST")]
    public class History
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public required string User { get; set; }
        public required string Type { get; set; }
        public required string Status { get; set; }
    }
}
