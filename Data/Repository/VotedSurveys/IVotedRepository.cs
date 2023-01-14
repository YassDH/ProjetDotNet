
using ProjetDotNet.Models.DBModels;

namespace ProjetDotNet.Data.Repository.VotedSurveys
{
    public interface IVotedRepository : IRepository<VotesDone>
    {
        IEnumerable<VotesDone> GetVotesByUser(Guid Id);
    }
}
