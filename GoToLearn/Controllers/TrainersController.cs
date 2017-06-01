using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using GoToLearn.Models;
using GoToLearn.ViewModels;

namespace GoToLearn.Controllers
{
    public class TrainersController : Controller
    {
        private ApplicationDbContext _context;

        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new TrainerFormViewModel
            {
                MembershipTypes = membershipTypes

            };
            return View("TrainerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TrainerFormViewModel
                {
                    Trainer = trainer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("TrainerForm", viewModel);
            }
            if (trainer.Id == 0)
            {
                _context.Trainers.Add(trainer);

            }
            else
            {
                var trainerInDb = _context.Trainers.Single(l => l.Id == trainer.Id);
                trainerInDb.Name = trainer.Name;
                trainerInDb.Birthdate = trainer.Birthdate;
                trainerInDb.Country = trainer.Country;
                trainerInDb.Sex = trainer.Sex;
                trainerInDb.Diploma = trainer.Diploma;
                trainerInDb.FieldId = trainer.FieldId;
                trainerInDb.MembershipTypeId = trainer.MembershipTypeId;
                trainerInDb.IsSubscribedToNewsletter = trainer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Trainers");
        }

        public ViewResult Index()
        {
            var trainers = _context.Trainers.Include(l => l.MembershipType).ToList();

            return View(trainers);
        }

        public ActionResult Details(int id)
        {
            var trainer = _context.Trainers.Include(l => l.MembershipType).SingleOrDefault(l => l.Id == id);

            if (trainer == null)
                return HttpNotFound();

            return View(trainer);
        }

        public ActionResult Edit(int id)
        {
            var trainer = _context.Trainers.SingleOrDefault(l => l.Id == id);
            if (trainer == null)
                return HttpNotFound();
            var viewModel = new TrainerFormViewModel
            {
                Trainer = trainer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("TrainerForm", viewModel);
        }
    }
}