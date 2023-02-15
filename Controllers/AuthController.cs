using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectionICR.Models;
using ElectionICR.Data;
using ElectionICR;
using ElectionICR.Auth_mod;

namespace ElectionICR.Controllers
{
    public class AuthController : ApiController
    {
        
        private CMSDBEntities db = new CMSDBEntities();

        [HttpGet]
        public IHttpActionResult ValidLogin(string userName, string userPassword)
        {
            if (userName == "admin" && userPassword == "admin")
            {
                LoginResponse resp = new LoginResponse
                {
                    email = userName,
                    token = TokenManager.GenerateToken(userName)
                };
                return Ok(resp);
            }
            else
            {
                return BadRequest("Account Details Mismatch or Does not Exists");
            }
        }

        //Login User
        [HttpPost]
        public IHttpActionResult LoginUser(Login request)
        {

            if(request == null)
            {
                return BadRequest("No Data Provided");
            }
            //Find the User Details
            var _userInstance = db.UserTbls.FirstOrDefault(h=>h.EmailAddress == request.email);
            if(_userInstance == null)
            {
                return BadRequest("No Matching Data Found");
            }

            //Check if the password and username matches
            if(_userInstance != null && HshClass.VerifyHash(request.password, "SHA512", _userInstance.Password) == false){
                return BadRequest("Login Details Mismatch");
            }
            //If the result is Successful
            LoginResponse resp = new LoginResponse();
            resp.email =request.email ;
            resp.token =TokenManager.GenerateToken(request.email);
            return Ok(resp);
        }

        

    }
}
