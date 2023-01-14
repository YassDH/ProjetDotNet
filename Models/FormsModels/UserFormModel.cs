namespace ProjetDotNet.Models.FormsModels
{
    public class UserFormModel
    {
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
