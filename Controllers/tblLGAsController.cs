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
    public class tblLGAsController : ApiController
    {
        private CMSDBEntities db = new CMSDBEntities();

        // GET: api/tblLGAs
        public IQueryable<tblLGA> GettblLGAs()
        {
            return db.tblLGAs;
        }

       
        public IHttpActionResult GettblLGA(int id)
        {
            var _inst = db.tblLGAs.FirstOrDefault(h=>h.LGAId == id);
            if (_inst == null)
            {
                return BadRequest("No Record Found");
            }
            LGAResponse resp = new LGAResponse();
            resp.StateID = _inst.tblState.StateId;
            resp.LGAID = _inst.LGAId;
            resp.LGAName = _inst.LGAName;
           
            return Ok(resp);
        }   

    }
}