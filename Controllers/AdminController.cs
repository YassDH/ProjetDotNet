using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjetDotNet.Data;
using ProjetDotNet.Data.UnitOfWork;
using ProjetDotNet.Models.DBModels;
using ProjetDotNet.Models.FormsModels;
using System.Diagnostics;

namespace ProjetDotNet.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProjectDBContext dbContext;
        public AdminController(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: AdminController1
        public ActionResult Index()
        {

            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            ViewData["name"] = "Student request";
            ViewBag.result = "admin";
            ViewBag.admin = 1;
            IEnumerable<Survey> surveys = unitOfWork.Survey.GetAll();
            ViewBag.survey = surveys;
            ViewBag.profil = user;
            return View();
        }
        [HttpPost]
        public ActionResult CloseForm(Survey ser)
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            Survey sur = unitOfWork.Survey.Get(ser.Id);
            sur.closed = 1;
            unitOfWork.Survey.UpdateSurveyType(sur);
            unitOfWork.Complete();
            ViewBag.profil = user;
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult deleteForm(Survey ser)
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            Survey sur = unitOfWork.Survey.Get(ser.Id);
            unitOfWork.Survey.Remove(sur);
            unitOfWork.Complete();
            ViewBag.profil = user;
            return RedirectToAction("index");
        }
        public ActionResult Results()
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            IEnumerable<Survey> closedSurveys = unitOfWork.Survey.GetClosedSurveys();
            ViewData["name"] = "Student request";
            ViewBag.result = "admin";
            ViewBag.admin = 1;
            ViewBag.profil = user;
            return View(closedSurveys);
        }
        public ActionResult Profil()
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            IEnumerable<Users> liseDesUsers = unitOfWork.Users.GetNotVerifiedUsers();

            ViewData["name"] = "Student request";
            ViewBag.result = "admin";
            ViewBag.admin = 1;
            ViewBag.users = liseDesUsers;
            ViewBag.profil = user;
            return View();
        }

        [HttpPost]
        public ActionResult Accept(UserLoginForm user)
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users userF = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (userF == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!userF.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            Users userFound = unitOfWork.Users.GetUserByEmail(user.email);
            userFound.isVerified = true;
            unitOfWork.Users.UpdateUserVerified(userFound);
            unitOfWork.Complete();
            ViewBag.profil = user;
            return RedirectToAction("Profil");
        }
        [HttpPost]
        public ActionResult Decline(UserLoginForm user)
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users userF = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (userF == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!userF.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            Users userFound = unitOfWork.Users.GetUserByEmail(user.email);


            unitOfWork.Users.Remove(userFound);
            unitOfWork.Complete();
            ViewBag.profil = user;
            return RedirectToAction("Profil");
        }

        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            ViewData["name"] = "Student request";
            ViewBag.result = "admin";
            ViewBag.admin = 1;
            ViewBag.profil = user;
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddSurveyForm surveyData)
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString(key: "SessionID"));
            if(user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (!user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            Survey survey = new Survey()
            {
                Id = Guid.NewGuid(),
                Question = surveyData.Question,
                Description = surveyData.Description,
                closed = 0,
                votesNumber = 0,
                Option1 = surveyData.Option1,
                Option2 = surveyData.Option2,
                Option3 = surveyData.Option3,
                Option4 = surveyData.Option4,
                Option5 = surveyData.Option5,
                Option6 = surveyData.Option6,
                nbVotesChoix1 = 0,
                nbVotesChoix2 = 0,
                nbVotesChoix3 = 0,
                nbVotesChoix4 = 0,
                nbVotesChoix5 = 0,
                nbVotesChoix6 = 0

                
            };
            unitOfWork.Survey.Add(survey);
            unitOfWork.Complete();
            
          

            ViewData["name"] = "Student request";
            ViewBag.result = "admin";
            ViewBag.profil = user;
            ViewBag.admin = 1;
            return RedirectToAction("Index"); //TO INDEX
        }


    }
}
