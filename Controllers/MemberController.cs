using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectionICR.Models;
using ElectionICR;
using ElectionICR.Auth_mod;

namespace ElectionICR.Controllers
{
    public class MemberController : ApiController
    {
        private CMSDBEntities db = new CMSDBEntities();

        //Return List of all Members
        [HttpGet]
        public IQueryable<tblINECVotersRegister> GetAllUser()
        {

            return db.tblINECVotersRegisters; 
        }

        //Get A Single member Record
        [CustomAuthenticationFilter]
        [HttpGet]
        public IHttpActionResult GetData(int voterRegID)
        {
            var _memberInstance = db.tblINECVotersRegisters.FirstOrDefault(h => h.VotersRegisterID == voterRegID);
            if (_memberInstance == null)
            {
                return BadRequest("No Matching Record Found");
            }

            return Ok(_memberInstance);
        }

        
        //Register A New Member Record
        [CustomAuthenticationFilter]
        [HttpPost]
        public IHttpActionResult RegisterMember(tblINECVotersRegister request)
        {

            if(request == null)
            {   
                return BadRequest("No Data Provided, A Member must have atleast an Email Address");
            }

            // Find User Instance From the database
            var _userInstance = db.tblINECVotersRegisters.FirstOrDefault(h => h.EmailAddress == request.EmailAddress);
            
            //Checks if the user record already exists
            if (_userInstance == null)
            {
                return BadRequest("A User with the Same Email Address Already Exists");
            }

            //GENERATE RANDOM NUMBER FOR REG NUMBER
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                var _id = rnd.Next();
            }

            //Registering The User Record
            tblINECVotersRegister data = new tblINECVotersRegister();
            data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Date;
            db.tblINECVotersRegisters.Add(data);
            db.SaveChanges();

            return Ok("Member Registeation Successfully");



        }
        
        //Delete Member's Record
        [HttpDelete]
        public IHttpActionResult DeleteMemberRecord(int voterRegID)
        {
            var _record = db.tblINECVotersRegisters.FirstOrDefault(h => h.VotersRegisterID == voterRegID);
            if(_record == null)
            {
                return BadRequest("No Record Found With that VoterRegID");
            }

            db.tblINECVotersRegisters.Remove(_record);
            db.SaveChanges();
            return Ok("Data Deleted Successfully");
        }
    }
}
