using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Model.Systempunk
{
    [Table("History", Schema = "SYST")]
    public class History
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public History() { }
    }
}