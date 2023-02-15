using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectionICR.Models;
using ElectionICR.Data;

namespace ElectionICR.Controllers
{
    public class PollingBoothController : ApiController
    {
        //Connects to the database
        private CMSDBEntities db = new CMSDBEntities();

        //List all Polling Boots
        public IQueryable<tblPollingBooth> GetTblPollingBooths()
        {
            return db.tblPollingBooths;
        }

        //Get Single Pooling Booth Based on ID
        [HttpGet]
        public IHttpActionResult GetSingleBooth(int poolingID)
        {
            var poolingBooth = db.tblPollingBooths.Where(h => h.PollingBoothId == poolingID).First();
            if(poolingBooth == null)
            {
                return BadRequest("No Record Found");
            }

            BoothResponse resp = new BoothResponse();
            resp.StateID = poolingBooth.tblState.StateId;
            resp.LGAID = poolingBooth.tblLGA.LGAId;
            resp.WardID = poolingBooth.tblWard.WardId;
            resp.PoolingBoothID = poolingBooth.PollingBoothId;
            resp.PoolingBoothCode = poolingBooth.PollingBoothCode;
            resp.PoolingBoothAddress = poolingBooth.Address;
            resp.PoolingBoothName = poolingBooth.PollingBoothName;
            return Ok(resp);
        }
    }
}
