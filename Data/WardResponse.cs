using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionICR.Data
{
    public class WardResponse
    {
   
        public int StateID { get; set; }

        public int LGAID { get; set; }

        public int WardID { get; set; }

        public string WardDescription { get; set; }
        
    }
}