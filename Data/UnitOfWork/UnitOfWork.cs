using ProjetDotNet.Data.Repository.SurveysRepository;
using ProjetDotNet.Data.Repository.UsersRepository;
using ProjetDotNet.Data.Repository.VotedSurveys;

namespace ProjetDotNet.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ProjectDBContext applicationDBContext;
        public IUsersRepository Users { get; private set; }
        public ISurveyRepository Survey { get; private set; }

        public IVotedRepository Voted { get; private set; }


        public UnitOfWork(ProjectDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
            Users = new UsersRepository(applicationDBContext);
            Survey = new SurveysRepository(applicationDBContext);
            Voted = new VotedRepository(applicationDBContext);
        }

        public bool Complete()
        {
            try
            {
                int result = applicationDBContext.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Dispose()
        {
            applicationDBContext.Dispose();
        }
    }
}
