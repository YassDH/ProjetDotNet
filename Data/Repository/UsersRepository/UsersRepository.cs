using ProjetDotNet.Models.DBModels;

namespace ProjetDotNet.Data.Repository.UsersRepository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly ProjectDBContext applicationDBContext;
        public UsersRepository(ProjectDBContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public Users GetUserByCarteEtudiant(long carte)
        {
            if (applicationDBContext.Users.Where(a => a.carteEtudiant == carte).Count() != 0)
            {
                return applicationDBContext.Users.Where(a => a.carteEtudiant == carte).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public Users GetUserByEmail(string email)
        {
            if (applicationDBContext.Users.Where(a => a.email == email).Count() != 0)
            {
                return applicationDBContext.Users.Where(a => a.email == email).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Users> GetNotVerifiedUsers()
        {
            if (applicationDBContext.Users.Where(a => a.isVerified == false).Count() != 0)
            {
                return applicationDBContext.Users.Where(a => a.isVerified == false).ToList();
            }
            else
            {
                return null;
            }
        }
        public void UpdateUserVerified(Users user)
        {
            user.isVerified = true;
            applicationDBContext.Users.Update(user);

        }

    }
}
