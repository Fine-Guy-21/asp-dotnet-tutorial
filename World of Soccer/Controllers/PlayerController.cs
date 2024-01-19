using Microsoft.AspNetCore.Mvc;
using World_of_Soccer.Models;

namespace World_of_Soccer.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SoccerContext SoccerCon;

        public PlayerController(IWebHostEnvironment webHostEnvironment,SoccerContext SoccerCon)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.SoccerCon = SoccerCon;
        }
        public IActionResult Index()
        {
            return View();
        }
        public List<Player> GetAllPlayers2()
        {
            PlayerRepository pr = new PlayerRepository();
            return pr.GetAllPlayers();
            //return View();
        }

        public IActionResult GetAllPlayers()
        {
            PlayerRepository pr = new PlayerRepository();
            ViewData["gap"] = pr.GetAllPlayers();
            TeamRepository tr = new TeamRepository(SoccerCon);
            ViewData["gat"] = tr.GetAllTeams();
            //return pr.GetAllPlayers();
            return View();
        }
    }
}
