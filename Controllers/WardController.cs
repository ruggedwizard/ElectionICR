using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectionICR.Data;
using ElectionICR.Models;

namespace ElectionICR.Controllers
{
    public class WardController : ApiController
    {
        private CMSDBEntities db = new CMSDBEntities();

        [HttpGet]
        public IQueryable<tblWard> GetAllWard()
        {
            return db.tblWards.AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult GetWard(int wardId)
        {
            var singleWard = db.tblWards.FirstOrDefault(h => h.WardId == wardId);
            if(singleWard == null)
            {
                return BadRequest("No Record Found");
            }
            WardResponse resp = new WardResponse();
            resp.StateID = singleWard.tblState.StateId;
            resp.LGAID = singleWard.tblLGA.LGAId;
            resp.WardID = singleWard.WardId;
            resp.WardDescription = singleWard.WardDescription;

            return Ok(resp);
        }
    }
}
