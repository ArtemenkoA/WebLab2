using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/<ValuesController>/5
        [HttpGet]
        public async Task<ActionResult<Detail>> Get([FromQuery] int id, [FromQuery] int count, [FromQuery] int adres)
        {
            List<Detail> Detail_list;
            Detail Detail1 = new Detail();
            using (var db = new ApplicationContext())
            {
                // получаем объекты из бд 
                Detail_list = db.Details.ToList();

                for (int i = 0; i < Detail_list.Count; i++)
                {
                    if (id == Detail_list[i].Id)
                    {
                        Detail1 = Detail_list[i];
                    }

                    else if (count == Detail_list[i].Count)
                    {
                        Detail1 = Detail_list[i];
                    }

                    else if (adres == Detail_list[i].Adres)
                    {
                        Detail1 = Detail_list[i];
                    }
                }
            }
            return new ObjectResult(Detail1);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public string Post(int id, int count, int adres)
        {
            using (var db = new ApplicationContext())
            {
                Detail Detail1 = new Detail();
                Detail1.Id = id;
                Detail1.Count = count;
                Detail1.Adres = adres;
                db.Details.Add(Detail1);
                db.SaveChanges();
            }
            return "success";
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int count)
        {
            List<Detail> Detail_list;
            Detail Detail1 = new Detail();
            using (var db = new ApplicationContext())
            {
                // получаем объекты из бд 
                Detail_list = db.Details.ToList();

                for (int i = 0; i < Detail_list.Count; i++)
                {
                    if (id == Detail_list[i].Id)
                    {
                        Detail1.Id = Detail_list[i].Id;
                        Detail1.Count = count;
                    }
                }
                db.Details.Update(Detail1);
                db.SaveChanges();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            List<Detail> Detail_list;
            Detail Detail1 = new Detail();
            using (var db = new ApplicationContext())
            {
                Detail_list = db.Details.ToList();

                for (int i = 0; i < Detail_list.Count; i++)
                {
                    if (id == Detail_list[i].Id)
                    {
                        Detail1 = Detail_list[i];
                    }
                }

                db.Details.Remove(Detail1);
                db.SaveChanges();
            }
            return "success";
        }
    }
}
