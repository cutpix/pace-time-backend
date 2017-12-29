using PaceTime.WebAPI.Data;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Collections.Generic;
using PaceTime.Domain.Models.Fitness;
using System.Linq;
using System;
using PaceTime.WebAPI.Models;

namespace PaceTime.WebAPI.Controllers
{
    [RoutePrefix("api/fitness")]
    public class FitnessController : ApiController
    {
        [HttpGet, Route("training/{sessionId}/session")]
        public async Task<IHttpActionResult> GetTrainingSession([FromUri] Guid sessionId)
        {
            using (var db = new FitnessContext())
            {
                var session = await db.TrainingSessions.FirstOrDefaultAsync(x => x.Id == sessionId);

                var payload = new
                {
                    SessionId = session.Id,
                    Created = session.Date,
                    Exercises = session.Sets.GroupBy(x => x.Exercise.Naming).Select(x => new
                    {
                        x.FirstOrDefault()?.Exercise.Naming,
                        Sets = x.Count(),
                        Reps = x.OrderBy(s => s.EndTime).Select(s => s.Repetitions).ToArray()
                    }).ToArray()
                };

                return Ok(payload);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetExercises()
        {
            var model = new List<Exercise>();

            using (var db = new FitnessContext())
                model = await db.Exercises.ToListAsync();

            var payload = model.Select(exe => new { ExerciseId = exe.Id, exe.Naming });

            return Ok(payload);
        }

        [HttpPost, Route("training/session/start")]
        public async Task<IHttpActionResult> StartTrainingSession()
        {
            Guid newSessionId = Guid.Empty;

            using (var db = new FitnessContext())
            {
                var session = db.TrainingSessions.Create();
                db.TrainingSessions.Add(session);
                await db.SaveChangesAsync();
            }

            return Ok(new { status = Progress.Started });
        }

        [HttpPost, Route("training/{sessionId}/session/set")]
        public async Task<IHttpActionResult> CreateTrainingSet([FromUri]Guid sessionId, [FromBody] TrainingSetModel set)
        {
            using (var db = new FitnessContext())
            {
                var newSet = db.TrainingSets.Create();

                var exercise = await db.Exercises.FirstOrDefaultAsync(x => x.Naming == set.Naming);
                var session = await db.TrainingSessions.FirstOrDefaultAsync(x => x.Id == sessionId);

                newSet.Exercise = exercise;
                newSet.TrainingSession = session;

                newSet.Repetitions = set.Repetitions;
                newSet.EndTime = DateTimeOffset.Now;

                newSet = db.TrainingSets.Add(newSet);

                await db.SaveChangesAsync();
            }


            return Ok();
        }
    }
}
