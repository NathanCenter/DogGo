using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Repositories;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Models.ViewModels;
using System.Security.Claims;
using System.Linq;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private readonly IOwnerRepository _ownerRepo;
        private readonly IDogRepository _dogRepo;
        private readonly IWalkerRepository _walkerRepo;
        private readonly INeighborhoodRepository _neighborhoodRepo;
        public WalkersController(
                   IOwnerRepository ownerRepository,
                   IDogRepository dogRepository,
                   IWalkerRepository walkerRepository,
                   INeighborhoodRepository neighborhoodRepository
                   )

        {
            _ownerRepo = ownerRepository;
            _dogRepo = dogRepository;
            _walkerRepo = walkerRepository;
            _neighborhoodRepo = neighborhoodRepository;
        }
        // GET: WalkersController
        public ActionResult Index()
        {

            //Update the Index method in the walkers controller so that owners only see walkers in their own neighborhood. 
            int ownerId = GetCurrentUserId();
    
            List<Walker> walkers = _walkerRepo.GetAllWalkers();
            if (ownerId != 0)
            {
                Owner owner=_ownerRepo.GetOwnerById(ownerId);
                List<Walker> listByNeighborhood = walkers.Where(w => w.NeighborhoodId == owner.NeighborhoodId).ToList();

                return View(listByNeighborhood);
            }
            else
            {
                return View(walkers);
            }

           
        }

        // GET: WalkersController/Details/5
        // GET: Walkers/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walks> walks = _walkerRepo.GetWalksFromWalker(walker.Id);

            WalkerFormModel wm = new WalkerFormModel
            {
                Walker = walker,
                Walks = walks
            };

            if (walker == null)
            {
                return NotFound();
            }

            return View(wm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
          
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(id);
            }
            
          
        }
    }
}
