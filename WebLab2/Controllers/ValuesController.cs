﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Diagnostics;

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
            if (Detail1 != null)
            {
                return NotFound();
            }
            else
            return new ObjectResult(Detail1);

        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Detail>> Post(int id, int count, int adres)
        {
            using (var db = new ApplicationContext())
            {
                Detail Detail1 = new Detail();
                Detail1.Id = id;
                Detail1.Count = count;
                Detail1.Adres = adres;
                db.Details.Add(Detail1);
                db.SaveChanges();
                return Ok();
            }
        }

        // PUT api/<ValuesController>/5 
        [HttpPut("{id}")]
        public async Task<ActionResult<Detail>> Put(int id, [FromBody] DetailDTO detailDTO)
        {
            using (var db = new ApplicationContext())
            {
                var Detail = db.Details.FirstOrDefault(x => x.Id == id);
                if (Detail != null)
                {
                    Detail.Adres = detailDTO.Adres;
                    Detail.Count = detailDTO.Count;
                    db.SaveChanges();
                }

                if (Detail == null)
                {
                    return NotFound();
                }
                else
                { return new ObjectResult(Detail); }
            }
         
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detail>> Delete(int id)
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
                    else if (id == 0)
                    {
                        return NotFound();
                    }
                }

                db.Details.Remove(Detail1);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpOptions]
        public ActionResult Options()
        {
            HttpContext.Response.Headers.Add("Allow", "GET, POST, OPTIONS, PUT, DELETE");
            return StatusCode(405);
        }


    } 
}
