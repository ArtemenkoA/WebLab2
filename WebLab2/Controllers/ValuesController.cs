using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Detail[] Details = new Detail[20];
                for (int i = 0; i < Details.Length; i++)
                {
                    Details[i].Id = i+12;
                    Details[i].Count = 36+i*2;
                    Details[i].Adres = i+22;
                }

                for (int i = 0; i < Details.Length; i++)
                {
                    db.Details.Add(Details[i]);

                }
                db.SaveChanges();
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
