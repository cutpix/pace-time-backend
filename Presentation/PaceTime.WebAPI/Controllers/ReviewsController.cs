using PaceTime.Domain.Models;
using PaceTime.WebAPI.Data;
using PaceTime.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PaceTime.WebAPI.Controllers
{
    public class ReviewsController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ReviewModel review)
        {
            using (var context = new BooksContext())
            {
                var book = await context.Books.FirstOrDefaultAsync(x => x.Id == Guid.Parse(review.BookId));
                if (book == null)
                    return NotFound();

                var newReview = context.Reviews.Add(new Review
                {
                    BookId = book.Id,
                    Description = review.Description,
                    Rating = review.Rating
                });

                await context.SaveChangesAsync();

                return Ok(new ReviewModel(newReview));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            using (var context = new BooksContext())
            {
                var review = await context.Reviews.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
                if (review == null)
                    return NotFound();

                context.Reviews.Remove(review);

                await context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
