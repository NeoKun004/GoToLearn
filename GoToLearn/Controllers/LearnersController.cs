using GoToLearn.Models;
using GoToLearn.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace GoToLearn.Controllers
{
    public class LearnersController : Controller
    {
        private ApplicationDbContext _context;

        public LearnersController()
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
            var viewModel = new LearnerFormViewModel
            {
                MembershipTypes = membershipTypes

            };
            return View("LearnerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Learner learner)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LearnerFormViewModel
                {
                    Learner = learner,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("LearnerForm", viewModel);
            }
            if (learner.Id == 0)
            {
                _context.Learners.Add(learner);

            }
            else
            {
                var learnerInDb = _context.Learners.Single(l => l.Id == learner.Id);
                learnerInDb.Name = learner.Name;
                learnerInDb.Birthdate = learner.Birthdate;
                learnerInDb.Sex = learner.Sex;
                learnerInDb.Level = learner.Level;
                learnerInDb.Country = learner.Country;
                learnerInDb.MembershipTypeId = learner.MembershipTypeId;
                learnerInDb.IsSubscribedToNewsletter = learner.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Learners");
        }



        public ViewResult Index()
        {
            var learners = _context.Learners.Include(l => l.MembershipType).ToList();

            return View(learners);
        }

        public ActionResult Details(int id)
        {
            var learner = _context.Learners.Include(l => l.MembershipType).SingleOrDefault(l => l.Id == id);

            if (learner == null)
                return HttpNotFound();

            return View(learner);
        }

        public ActionResult Edit(int id)
        {
            var learner = _context.Learners.SingleOrDefault(l => l.Id == id);
            if (learner == null)
                return HttpNotFound();
            var viewModel = new LearnerFormViewModel
            {
                Learner = learner,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("LearnerForm", viewModel);
        }
    }
}
