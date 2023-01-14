using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data;
using ProjetDotNet.Data.UnitOfWork;
using ProjetDotNet.Models.DBModels;
using ProjetDotNet.Models.FormsModels;
using System.Text.RegularExpressions;

namespace ProjetDotNet.Controllers
{
    public class LoginController : Controller
    {
        private readonly ProjectDBContext dbContext;
        public LoginController(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: LoginController 
        public IActionResult Index()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Index(UserLoginForm user)
        {
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users userFound = unitOfWork.Users.GetUserByEmail(user.email);
          
            if (userFound == null)
            {
                ViewBag.errorMessage = "Utilisateur Inexistant";
                return PartialView();
            }
            else
            {
                if(userFound.password != user.password) {
                    ViewBag.errorMessage = "Mot de passe Incorrect";
                    return PartialView();
                }
                else
                {
                    if (userFound.isAdmin)
                    {                        
                        HttpContext.Session.SetString("SessionID", userFound.email);
                        return RedirectToRoute(new {
                            controller = "Admin",
                            action = "Index"
                        });

                    }
                    else if (!userFound.isVerified)
                    {
                        ViewBag.errorMessage = "Votre compte n'est pas encore verifié";
                        return PartialView();
                    }
                    else
                    {
                        HttpContext.Session.SetString("SessionID", userFound.email);
                        return RedirectToRoute(new
                        {
                            controller = "Home",
                            action = "Index"
                        });
                    }
                }
            }
            
        }
        public IActionResult SignUp()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SignUp(UserFormModel userToAdd)
        {
            string classe;
            switch (userToAdd.classe)
            {
                case "1" : classe = "MPI";
                        break;
                case "2": classe = "GL2";
                    break ;
                case "3": classe = "RT2";
                    break;
                case"4": classe = "IIA2";
                    break;
                case"5": classe = "IMI2";
                    break;
                case "6": classe = "GL3";
                    break ;
                case "7": classe = "RT3";
                    break;
                case "8": classe = "IIA3";
                    break;
                case "9": classe = "IMI3";
                    break;
                case "10": classe = "GL4";
                    break ;
                case "11": classe = "RT4";
                    break;
                case "12": classe = "IIA4";
                    break;
                case "13": classe = "IMI4";
                    break;
                case "14": classe = "GL5";
                    break ;
                case "15": classe = "RT5";
                    break;
                case "16": classe = "IIA5";
                    break;
                case "17": classe = "IMI5";
                    break;

                default:
                    classe = "MPI";
                    break;
            }
            Users user = new Users()
            {
                Id = Guid.NewGuid(),
                nom = userToAdd.nom,
                prenom = userToAdd.prenom,
                email = userToAdd.email,
                password = userToAdd.password,
                carteEtudiant = userToAdd.carteEtudiant,
                classe = classe,
                isAdmin = false,
                isVerified = false
            };
            var unitOfWork = new UnitOfWork(dbContext);

            if ((user.carteEtudiant < 2000000) || (user.carteEtudiant > 3000000))
            {
                ViewBag.errorMessage = "Carte d'Etudiant invalide";
                return PartialView();
            }
            Regex regex = new Regex(@"^([\w\.\-]+)@insat.ucar.tn$");
            Match match = regex.Match(user.email);
            if (!match.Success)
            {
                ViewBag.errorMessage = "ajouter votre Email Institutionnel";
                return PartialView();
            }

            if (unitOfWork.Users.GetUserByCarteEtudiant(user.carteEtudiant) != null)
            {
                ViewBag.errorMessage = "Carte d'Etudiant deja utilisee";
                return PartialView();
            }
            else if (unitOfWork.Users.GetUserByEmail(user.email) != null)
            {
                ViewBag.errorMessage = "Adresse Mail deja utilisee";
                return PartialView();
            }


            bool res = unitOfWork.Users.Add(user);
            res = unitOfWork.Complete();

            return RedirectToAction("Index");
        }
        
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
