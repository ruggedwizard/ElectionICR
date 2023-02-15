using ElectionICR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectionICR.Data;

namespace ElectionICR.Controllers
{
    public class StateController : ApiController
    {
        //Create Database Context
        private CMSDBEntities db = new CMSDBEntities();

        //Get List of All States
        [HttpGet]
        public IQueryable<tblState> AllState()
        {
            return db.tblStates;
        }

        //Get A Single State
        [HttpGet]
        public IHttpActionResult singleState(string stateCode)
        {
            //Filter state with a given state code
            var  state = db.tblStates.FirstOrDefault(h => h.StateCode == stateCode);

            if (state == null)
            {
                return BadRequest("No Record Found");
            }

            //State Response
            StateResponse resp = new StateResponse();
            resp.StateCode = state.StateCode;
            resp.StateName = state.StateDescription;
            resp.StateID = state.StateId;

            return Ok(resp);
        }

    }
}
