using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;
using System.IO;
using System.Runtime.Intrinsics.X86;
using World_of_Soccer.Models;
using static System.Net.Mime.MediaTypeNames;

namespace World_of_Soccer.Controllers
{
    public class TeamController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SoccerContext SoccerCon;
        public TeamController (IWebHostEnvironment webHostEnvironment, SoccerContext SoccerCon)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.SoccerCon = SoccerCon;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateTeam(TeamViewModel tvm)
        {
            string uniqueCFileName = "";
            string  LogoFolder = Path.Combine(webHostEnvironment.WebRootPath, "Logo");
            string fileName = ""; 

            if (tvm.TeamLogo!=null)
            {
                fileName = Guid.NewGuid().ToString() + "_" + tvm.TeamLogo.FileName;
                uniqueCFileName = Path.Combine(LogoFolder, fileName);
                tvm.TeamLogo.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));
            }

            Team team = new Team()
            {
                TeamId = tvm.TeamId,
                TeamName = tvm.TeamName,
                TeamShortName = tvm.ShortTeamName,
                TeamCoach = tvm.CoachName,
                TeamLogo = "/Logo/" + fileName
            };

            team.TeamKits = new List<ImageGallery>();
 
            if (tvm.Kits != null)
            {
                string KitFolder = Path.Combine(webHostEnvironment.WebRootPath, "Kits");
                foreach (IFormFile pic in tvm.Kits)
                {
                    string KitPath = Path.Combine(KitFolder, tvm.ShortTeamName);
                    try
                    {
                        Directory.CreateDirectory(KitPath);

                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    fileName = Guid.NewGuid().ToString() + "_" + pic.FileName;

                    uniqueCFileName = Path.Combine(KitPath, fileName);
                    
                    pic.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));

                    var imagegallery = new ImageGallery();
                    imagegallery.Url = "/Kits/" + tvm.ShortTeamName + "/" + fileName;
                    team.TeamKits.Add(imagegallery);

                }
            }

            TeamRepository tr = new TeamRepository(SoccerCon);
            tr.AddTeam(team);
            return View();
        }
        

        public IActionResult GetAllTeams()
        {
            TeamRepository tr = new TeamRepository(SoccerCon);
            return View(tr.GetAllTeams());
        }
        public IActionResult GetTeamByID(int id)
        {
            TeamRepository tr = new TeamRepository(SoccerCon);
            Team team = tr.GetTeamById(id);
            return View(team);
        }

        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            TeamRepository tr = new TeamRepository(SoccerCon);
            Team team = tr.GetTeamById(id);

            TeamViewModel tvm = new TeamViewModel()
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                ShortTeamName = team.TeamShortName,
                CoachName = team.TeamCoach
            };
            
            ViewData["team"] = GetTeamByID(id);

            return View(tvm);
        }
        [HttpPost]
        public IActionResult UpdateTeam(TeamViewModel tvm)
        {
            //Team team = SoccerCon.Teams.Find(tvm.TeamId);
            Team? team = SoccerCon.Teams.Where(t => t.TeamId == tvm.TeamId).FirstOrDefault();


            TeamRepository tr = new TeamRepository(SoccerCon);
            string uniqueCFileName = "";
            string LogoFolder = Path.Combine(webHostEnvironment.WebRootPath, "Logo");
            string fileName = "";
            
            if (tvm.TeamLogo != null && team!=null)
            {
                fileName = Guid.NewGuid().ToString() + "_" + tvm.TeamLogo.FileName;
                uniqueCFileName = Path.Combine(LogoFolder, fileName);
                tvm.TeamLogo.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));

                team.TeamId = tvm.TeamId;
                team.TeamName = tvm.TeamName;
                team.TeamShortName = tvm.ShortTeamName;
                team.TeamCoach = tvm.CoachName;
                team.TeamLogo = "/Logo/" + fileName;
            }
            
            
                tr.UpdateTeam(team);
                return RedirectToAction("GetAllTeams");
            
        }

        
        public IActionResult DeleteTeam(int id)
        {
            TeamRepository tr = new TeamRepository(SoccerCon);
            Team? team = SoccerCon.Teams.Where(t => t.TeamId == id).FirstOrDefault();
            List<ImageGallery> images = SoccerCon.imageGalleries.Where(t=>t.Id == id).ToList();
            foreach (ImageGallery Pic in images)
            {
                SoccerCon.imageGalleries.Remove(Pic);
                SoccerCon.SaveChanges();
            }

            tr.DeleteTeam(team); 
            return View("GetAllTeams" , tr.GetAllTeams());
        }
    }
}
