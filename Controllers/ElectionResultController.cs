using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectionICR.Models;
using ElectionICR.Data;
using ElectionICR.Auth_mod;

namespace ElectionICR.Controllers
{
    public class ElectionResultController : ApiController
    {
        //Connect to the Database with the 
        private CMSDBEntities db = new CMSDBEntities();

        [CustomAuthenticationFilter]
        [HttpGet]
        public IHttpActionResult GetAllresult()
        {

            return Ok(db.tblElectionResults.ToList());
        }

        [CustomAuthenticationFilter]
        [HttpPost]
        public IHttpActionResult CreateResult(tblElectionResult request)
        {
            var data = request;
            
            if(data == null)
            {
                return BadRequest("No Data Provided");
            }
            request.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy")).Date;
            db.tblElectionResults.Add(request);
            db.SaveChanges();
            return Ok("Result Data Added");
          
       
        }
    }
}
