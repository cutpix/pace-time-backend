using PaceTime.WebAPI.Data;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;


namespace PaceTime.WebAPI.Controllers
{
    public class PersonalTrainerController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetExercises()
        {
            using (var db = new BooksContext())
                return Ok(await db.Exercises.ToListAsync());
        }

        [HttpPost]
        public async Task<IHttpActionResult> StartTrainingSession()
        {
            using (var db = new BooksContext())
            {
                var session = db.TrainingSessions.Create();

                db.TrainingSessions.Add(session);
                await db.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
