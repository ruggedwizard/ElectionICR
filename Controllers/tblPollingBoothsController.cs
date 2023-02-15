using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ElectionICR.Models;
using ElectionICR.Data;

namespace ElectionICR.Controllers
{
    public class tblPollingBoothsController : ApiController
    {
        private CMSDBEntities db = new CMSDBEntities();

        // GET: api/tblPollingBooths
        public IQueryable<tblPollingBooth> GettblPollingBooths()
        {
            return db.tblPollingBooths;
        }

        // GET: api/tblPollingBooths/5
        
        public IHttpActionResult GettblPollingBooth(int poolingId)
        {
            tblPollingBooth tblPollingBooth = db.tblPollingBooths.FirstOrDefault(h=>h.PollingBoothId==poolingId);
            if (tblPollingBooth == null)
            {
                return BadRequest("No Data Found");
            }

            BoothResponse resp = new BoothResponse();
            resp.PoolingBoothAddress = tblPollingBooth.Address;
            resp.PoolingBoothName = tblPollingBooth.PollingBoothName;
            resp.PoolingBoothCode = tblPollingBooth.PollingBoothCode;
            resp.PoolingBoothID = tblPollingBooth.PollingBoothId;
            resp.LGAID = tblPollingBooth.tblLGA.LGAId;
            resp.StateID = tblPollingBooth.tblState.StateId;


            return Ok(resp);
        }

    }
}