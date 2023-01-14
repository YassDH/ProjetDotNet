

using ProjetDotNet.Data.Repository.SurveysRepository;
using ProjetDotNet.Data.Repository.UsersRepository;
using ProjetDotNet.Data.Repository.VotedSurveys;

namespace ProjetDotNet.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        ISurveyRepository Survey { get; }
        IUsersRepository Users { get; }

        IVotedRepository Voted { get; }

        
       
        bool Complete();

    }
}
