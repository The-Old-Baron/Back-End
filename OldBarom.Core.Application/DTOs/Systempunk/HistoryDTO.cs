namespace OldBarom.Core.Application.DTOs.Systempunk
{
    public class HistoryDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public required string User { get; set; }
    }
}
