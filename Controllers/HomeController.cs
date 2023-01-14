using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Data;
using ProjetDotNet.Data.UnitOfWork;
using ProjetDotNet.Models;
using ProjetDotNet.Models.DBModels;
using ProjetDotNet.Models.FormsModels;
using System.Diagnostics;

namespace ProjetDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectDBContext dbContext;
        public HomeController(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index()
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
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString("SessionID"));
            if( user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Admin",
                    action = "Index"
                });
            }   


            IEnumerable<Survey> Surveys = unitOfWork.Survey.GetNonVotedSurveys(user.Id);
            ViewBag.surveys = Surveys;
            
            ViewData["name"] = "Profile";
            ViewBag.result = "Home";
            ViewBag.profil = user;
            return View();
        }
        public IActionResult Results()
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
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString("SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Admin",
                    action = "Index"
                });
            }
            IEnumerable<Survey> closedSurveys = unitOfWork.Survey.GetClosedSurveys();



            ViewData["name"] = "Profile";
            ViewBag.result = "Home";
            ViewBag.profil = user;
            return View(closedSurveys);
        }

        public IActionResult Profil()

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
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString("SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Admin",
                    action = "Index"
                });
            }

            ViewData["name"] = "Profile";
            ViewBag.result = "Home";
            ViewBag.profil = user;
            return View(user);
        }
        [HttpPost]
        public IActionResult Vote(Guid id)

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
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString("SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Admin",
                    action = "Index"
                });
            }
            Survey s = unitOfWork.Survey.Get(id);
            ViewData["name"] = "Profile";
            ViewBag.result = "Home";
            ViewBag.Survey = s;
            ViewBag.profil = user;
            return View();
        }
        [HttpPost]
        public ActionResult SaveVote(VoteForm vote)
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
            Users user = unitOfWork.Users.GetUserByEmail(HttpContext.Session.GetString("SessionID"));
            if (user == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Login",
                    action = "Index"
                });
            }
            if (user.isAdmin)
            {
                return RedirectToRoute(new
                {
                    controller = "Admin",
                    action = "Index"
                });
            }

            Survey s = unitOfWork.Survey.Get(vote.Id);
            s.votesNumber = s.votesNumber + 1;
            if(vote.check1 == "{ value = 1 }")
            {
                s.nbVotesChoix1 = s.nbVotesChoix1 + 1;
            }else if(vote.check1 == "{ value = 2 }")
            {
                s.nbVotesChoix2 = s.nbVotesChoix2 + 1;
            }else if (vote.check1 == "{ value = 3 }")
            {
                s.nbVotesChoix3 = s.nbVotesChoix3+ 1;
            }else if( vote.check1 == "{ value = 4 }")
            {
                s.nbVotesChoix4 = s.nbVotesChoix4 + 1;
            }else if(vote.check1 == "{ value = 5 }")
            {
                s.nbVotesChoix5 = s.nbVotesChoix5 + 1;
            }else if (vote.check1 == "{ value = 5 }")
            {
                s.nbVotesChoix6 = s.nbVotesChoix6 + 1;
            }

            VotesDone votedSer = new VotesDone()
            {
                Id = Guid.NewGuid(),
                Survey = s,
                Users = user
            };
            unitOfWork.Voted.Add(votedSer);

            unitOfWork.Survey.UpdateVote(s);
            unitOfWork.Complete();
            ViewBag.profil = user;
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}