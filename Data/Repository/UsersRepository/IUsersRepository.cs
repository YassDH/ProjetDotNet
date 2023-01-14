using ProjetDotNet.Models.DBModels;

namespace ProjetDotNet.Data.Repository.UsersRepository
{
    public interface IUsersRepository : IRepository<Users>
    {
        Users GetUserByCarteEtudiant(long carte);
        Users GetUserByEmail(string email);
        IEnumerable<Users> GetNotVerifiedUsers();
        void UpdateUserVerified(Users user);
    }
}
