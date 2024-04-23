using _413FinalCameronHammond.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using System.Linq;

namespace _413FinalCameronHammond.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFinalProjectRepository _repo;
        //private IFinalProjectRepository _repo;

        public HomeController(IFinalProjectRepository repo)
        {
            _repo = repo;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ArtistList()
        {
            var entertainers = _repo.Entertainers.ToList(); // Fetch all entertainers and convert to List
            return View(entertainers); // Pass the list of entertainers to the view
        }


        [HttpGet]
        public IActionResult AddArtist()
        {
            return View(new Entertainers());
        }

        [HttpPost]
        public IActionResult AddArtist(Entertainers entertainer)
        {
            entertainer.DateEntered = DateOnly.FromDateTime(DateTime.Now);

            _repo.AddEntertainer(entertainer);
            _repo.SaveChanges();
            
            return RedirectToAction("ArtistList");
        }

        public IActionResult ArtistDetails()
        {
            return View();
        }
        
    }
}
