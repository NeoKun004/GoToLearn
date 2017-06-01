using GoToLearn.Models;
using GoToLearn.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System;

namespace GoToLearn.Controllers
{
    public class TrainingsController : Controller
    {
        private ApplicationDbContext _context;
        public TrainingsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {


            return View("List");

        }
      
        public ViewResult New()
        {
            var fields = _context.Fields.ToList();

            var viewModel = new TrainingFormViewModel
            {
                Fields = fields
            };

            return View("TrainingForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var training = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (training == null)
                return HttpNotFound();

            var viewModel = new TrainingFormViewModel(training)
            {

                Fields = _context.Fields.ToList()
            };

            return View("TrainingForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var training = _context.Trainings.Include(m => m.Field).SingleOrDefault(m => m.Id == id);

            if (training == null)
                return HttpNotFound();

            return View(training);

        }

        // GET: Trainings/Random
        public ActionResult Random()
        {
            var training = new Training { Title = "NodeJs!" };
            var learners = new List<Learner>
            {
                new Learner { Name = "BOKUTOOO HEY HEY HEY" },
                new Learner { Name = "AKASHI" }
            };

            var viewModel = new RandomViewModel.RandomTrainingViewModel
            {
                Training = training,
                Learners = learners
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Training training)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TrainingFormViewModel
                {
                    Fields = _context.Fields.ToList()

                };
                return View("TrainingForm", viewModel);
            }
            if (training.Id == 0)
            {
                training.DateAdded = DateTime.Now;
                _context.Trainings.Add(training);
            }
            else
            {
                var trainingInDb = _context.Trainings.Single(m => m.Id == training.Id);
                trainingInDb.Title = training.Title;
                trainingInDb.FieldId = training.FieldId;
                trainingInDb.Duration = training.Duration;
                trainingInDb.TrainingDate = training.TrainingDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Trainings");
        }

    }
}