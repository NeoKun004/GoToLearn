using GoToLearn.Dtos;
using GoToLearn.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
namespace GoToLearn.Controllers.Api
{
    public class TrainersController : ApiController
    {
        private ApplicationDbContext _context;

        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/trainiers
        public IHttpActionResult GetTrainers()
        {
            var trainerdto = _context.Trainers.ToList().Select(Mapper.Map<Trainer, TrainerDto>);
            return Ok(trainerdto);
        }

        //GET/api/trainer/1
        public IHttpActionResult GetTrainer(int id)
        {
            var trainer = _context.Trainers.SingleOrDefault(c => c.Id == id);
            if (trainer == null)
                return NotFound();
            return Ok(Mapper.Map<Trainer, TrainerDto>(trainer));
        }

        //POST/api/trainers
        [HttpPost]
        public IHttpActionResult CreateTrainer(TrainerDto trainerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var trainer = Mapper.Map<TrainerDto, Trainer>(trainerDto);
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + trainer.Id), trainerDto);
        }

        //PUT/api/trainers
        public IHttpActionResult UpdateTrainer(int id, TrainerDto trainerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var trainerInDb = _context.Trainers.SingleOrDefault(c => c.Id == id);
            if (trainerInDb == null)
                return NotFound();

            Mapper.Map<TrainerDto, Trainer>(trainerDto, trainerInDb);
            _context.SaveChanges();
            return Ok();
        }


        //DELETE/api/trainers
        [HttpDelete]
        public IHttpActionResult DeleteTrainer(int id, Trainer trainer)
        {

            var trainerInDb = _context.Trainers.SingleOrDefault(c => c.Id == id);
            if (trainerInDb == null)
                return NotFound();
            _context.Trainers.Remove(trainerInDb);
            _context.SaveChanges();
            return Ok();


        }
    }
}
