using ProjetDotNet.Models.DBModels;

namespace ProjetDotNet.Data.Repository.VotedSurveys
{
    public class VotedRepository : Repository<VotesDone>, IVotedRepository
    {
        private readonly ProjectDBContext applicationDBContext;
        public VotedRepository(ProjectDBContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public IEnumerable<VotesDone> GetVotesByUser(Guid Id)
        {
            return applicationDBContext.VotedSurveys.Where(a=> a.Users.Id == Id).ToList();
        }
    }
}
