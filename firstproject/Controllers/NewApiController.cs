using firstproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace firstproject.Controllers
{
    public class NewApiController : ApiController
    {

        mydbEntities obj = new mydbEntities();
        [HttpGet]
        public IHttpActionResult show()
        {
            var res = obj.testingtable.ToList();
            return Ok(res);
        }

        [HttpGet]
        public IHttpActionResult show1(int id)
        {
            var res = obj.testingtable.Where(a=>a.id==id).FirstOrDefault() ;
            return Ok(res);
        }

        [HttpPost]
        public IHttpActionResult Insertvalues(testingtable tbl)
        {
            obj.testingtable.Add(tbl);
            obj.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult updatevalues(testingtable tbl)
        {
            /*var res = obj.testingtable.Where(a => a.id == tbl.id).FirstOrDefault();
            if (res!=null)
            {
                res.id = tbl.id;
                res.name = tbl.name;
                res.email = tbl.email;
                res.roll = tbl.roll;
                res.college = tbl.college;
                res.city = tbl.city;
                obj.SaveChanges();
            }
            else
            {
                return NotFound();
            }*/

            obj.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            obj.SaveChanges();
            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult Deletevalues(int id)
        {
            var res = obj.testingtable.Where(a => a.id == id).FirstOrDefault();
            obj.Entry(res).State = System.Data.Entity.EntityState.Deleted;
            obj.SaveChanges();
            return Ok();
        }


    }
}
