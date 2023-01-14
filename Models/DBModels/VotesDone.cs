namespace ProjetDotNet.Models.DBModels
{
    public class VotesDone
    {
        public Guid Id { get; set; }
        public Users Users { get; set; }
        public Survey Survey { get; set; }
    }
}
