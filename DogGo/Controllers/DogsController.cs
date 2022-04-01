using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DogGo.Controllers
{
    public class DogsController : Controller
    {

        private readonly IOwnerRepository _ownerRepo;
        private readonly IDogRepository _dogRepo;
        private readonly IWalkerRepository _walkerRepo;
        private readonly INeighborhoodRepository _neighborhoodRepo;

        // GET: DogController

        public DogsController(
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
       
        // GET: OwnersController
       
        // GET: DogController/Details/5
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);

            return View(dogs);
        }
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogsById(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);


        }
        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Dog dog)
        {
            try
            {
                // update the dogs OwnerId to the current user's Id
                dog.OwnerId = GetCurrentUserId();

                _dogRepo.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {
            
            Dog dog = _dogRepo.GetDogsById(id);

            if (dog == null || dog.OwnerId != GetCurrentUserId())
            {
                return NotFound();
            }
            else
            {
                return View(dog);
            }
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                _dogRepo.UpdateDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

  


        // GET: DogController/Delete/5
        
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepo.GetDogsById(id);

            if (dog == null || dog.OwnerId != GetCurrentUserId())
            {
                return NotFound();
            }
            else
            {
                return View(dog);
            }
        }

        // POST: DogController/Delete/5


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.UpdateDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
