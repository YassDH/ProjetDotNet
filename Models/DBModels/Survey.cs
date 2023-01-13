namespace ProjetDotNet.Models.DBModels
{
    public class Survey
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string? Description { get; set; }
        public int closed { get; set; }
        public int votesNumber { get; set; }
        public IEnumerable<Option> options { get; set; }
    }
}
