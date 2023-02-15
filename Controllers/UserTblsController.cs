using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ElectionICR.Models;

namespace ElectionICR.Controllers
{
    public class UserTblsController : ApiController
    {
        private CMSDBEntities db = new CMSDBEntities();

        // GET: api/UserTbls
        public IQueryable<UserTbl> GetUserTbls()
        {
            return db.UserTbls;
        }
        
        // GET: api/UserTbls/5
        [ResponseType(typeof(UserTbl))]
        public IHttpActionResult GetUserTbl(string userIdentificationNo)
        {
            var  userTbl = db.UserTbls.FirstOrDefault(h => h.UserIdenfiticationNumber == userIdentificationNo);
            if (userTbl == null)
            {
                return BadRequest("User Details Not Found");
            }

            return Ok(userTbl);
        }

        //Register A New User
        [HttpPost]
        public IHttpActionResult RegisterMember(UserTbl request)
        {

            var _emailInstance = db.UserTbls.FirstOrDefault(h => h.EmailAddress == request.EmailAddress);
            if (_emailInstance != null)
            {
                return BadRequest("User with that email address Already Exists");
            }
            //Check if the user with the same email address exist


            //RANDOM NUMBER GENERATE
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                var _id = rnd.Next();
            }

            //Saving New Record 
            request.UserIdenfiticationNumber = "ICR" + Convert.ToString(rnd.Next());
            request.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Date;
            request.ModifiedDate = null;
            request.UserApprovalStatus = "Approved";
            db.UserTbls.Add(request);
            db.SaveChanges();

            return Ok("Registeration Successfull");
            
        }
        
        //DELETE A USER RECORD
              
        public IHttpActionResult DeleteUserTbl(string id)
        {
            UserTbl userTbl = db.UserTbls.FirstOrDefault(h => h.UserIdenfiticationNumber == id);
            if (userTbl == null)
            {
                return BadRequest("ID NOT FOUND");
            }

            db.UserTbls.Remove(userTbl);
            db.SaveChanges();

            return Ok("DATA DELETED SUCCESSFULLY");
        }
    }
}