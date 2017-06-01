using GoToLearn.Dtos;
using GoToLearn.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using System.Collections.Generic;

namespace GoToLearn.Controllers.Api
{
    public class TrainingsController : ApiController
    {
        private ApplicationDbContext _context;

        public TrainingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TrainingDto> GetTrainings()
        {
            return _context.Trainings
                .Include(m => m.Field)
                .ToList()
                .Select(Mapper.Map<Training, TrainingDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Training, TrainingDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateTraining(TrainingDto trainingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var training = Mapper.Map<TrainingDto, Training>(trainingDto);
            _context.Trainings.Add(training);
            _context.SaveChanges();

            trainingDto.Id = training.Id;
            return Created(new Uri(Request.RequestUri + "/" + training.Id), trainingDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateTraining(int id, TrainingDto trainingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trainningInDb = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (trainningInDb == null)
                return NotFound();

            Mapper.Map(trainingDto, trainningInDb);

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult DeleteTraining(int id)
        {
            var trainningInDb = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (trainningInDb == null)
                return NotFound();

            _context.Trainings.Remove(trainningInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
