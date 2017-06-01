using GoToLearn.Dtos;
using GoToLearn.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;

namespace GoToLearn.Controllers.Api
{
    public class LearnersController : ApiController
    {
        private ApplicationDbContext _context;


        public LearnersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/learners
        public IHttpActionResult GetLearners()
        {
            var learnerdtos = _context.Learners.Include(c => c.MembershipType)
                 .ToList().
                 Select(Mapper.Map<Learner, LearnerDto>);
            return Ok(learnerdtos);
        }

        //GET/api/learners/1
        public IHttpActionResult GetLearner(int id)
        {
            var learner = _context.Learners.SingleOrDefault(c => c.Id == id);
            if (learner == null)
                return NotFound();
            return Ok(Mapper.Map<Learner, LearnerDto>(learner));
        }
        //POST/api/learners
        [HttpPost]
        public IHttpActionResult CreateLearner(LearnerDto learnerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var learner = Mapper.Map<LearnerDto, Learner>(learnerDto);
            _context.Learners.Add(learner);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + learner.Id), learnerDto);
        }

        //PUT/api/learners
        public IHttpActionResult UpdateLearner(int id, LearnerDto learnerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var learnerInDb = _context.Learners.SingleOrDefault(c => c.Id == id);
            if (learnerInDb == null)
                return NotFound();

            Mapper.Map<LearnerDto, Learner>(learnerDto, learnerInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE/api/learners
        [HttpDelete]
        public IHttpActionResult DeleteLearner(int id, Learner learner)
        {

            var learnerInDb = _context.Learners.SingleOrDefault(c => c.Id == id);
            if (learnerInDb == null)
                return NotFound();
            _context.Learners.Remove(learnerInDb);
            _context.SaveChanges();
            return Ok();


        }

    }
}
