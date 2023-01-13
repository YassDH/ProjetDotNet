namespace ProjetDotNet.Models.DBModels
{
    public class Users
    {
        public Guid Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public long carteEtudiant { get; set; }
        public string classe { get; set; }
        public bool isAdmin { get; set; }
        public bool isVerified { get; set; }

    }
}
