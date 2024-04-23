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

        // Artist Details Functionality
        public IActionResult ArtistDetails(int entertainerId)
        {
            var entertainer = _repo.Entertainers.FirstOrDefault(e => e.EntertainerID == entertainerId);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }




        // Add Artist Functionality

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

       

        // Edit Artist Functionality

        [HttpPost]
        public IActionResult GoToEditArtistView(int id)
        {
            var entertainer = _repo.Entertainers.FirstOrDefault(e => e.EntertainerID == id);
            return View("EditArtist", entertainer);
        }

        [HttpPost]
        public IActionResult EditArtist(Entertainers entertainer)
        {
            _repo.EditEntertainer(entertainer);
            _repo.SaveChanges();
            return RedirectToAction("ArtistDetails", new { entertainerId = entertainer.EntertainerID });
        }

        // Delete Artist Functionality
        //
        [HttpPost]
        public IActionResult GOToDeleteArtistConfrimation(int id)
        {
            var entertainer = _repo.Entertainers.FirstOrDefault(e => e.EntertainerID == id);
            return View("DeletConfirmation", entertainer);
        }


        
        public IActionResult DeleteArtist(Entertainers entertainer)
        {
            _repo.DeleteEntertainer(entertainer);
            _repo.SaveChanges();
            return RedirectToAction("ArtistList");
        }
    }
}
