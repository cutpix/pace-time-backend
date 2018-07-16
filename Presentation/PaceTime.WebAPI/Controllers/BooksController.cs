using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using PaceTime.WebAPI.Data;

namespace PaceTime.WebAPI.Controllers
{
    public class BooksController : ApiController
    {
        //[HttpGet]
        //public async Task<IHttpActionResult> Get()
        //{
        //    using (var context = new FitnessContext())
        //        return Ok(await context.Books.Include(x => x.Reviews).ToListAsync());
        //}

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var payload = new { };

            try
            {
                using (var client = HttpClientFactory.Create())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/http"));

                    var response = await client.GetAsync("https://www.goodreads.com/search.xml?key=sPtYrUlrixEYMsEoTBZNA&q=Ender%27s+Game");
                    if (response.IsSuccessStatusCode)
                    {
                        var message = await response.Content.ReadAsHttpResponseMessageAsync();

                    }



                    return Ok();
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
