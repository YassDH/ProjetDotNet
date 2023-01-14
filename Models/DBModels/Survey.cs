namespace ProjetDotNet.Models.DBModels
{
    public class Survey
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string? Description { get; set; }
        public int closed { get; set; }
        public int votesNumber { get; set; }
        
        public string Option1 { get; set; }
        public int nbVotesChoix1 { get; set; }
        public string Option2 { get; set; }
        public int nbVotesChoix2 { get; set; }
        public string? Option3 { get; set; }
        public int nbVotesChoix3 { get; set; }
        public string? Option4 { get; set; }
        public int nbVotesChoix4 { get; set; }
        public string? Option5 { get; set; }
        public int nbVotesChoix5 { get; set; }
        public string? Option6 { get; set; }
        public int nbVotesChoix6 { get; set; }



    }
}
