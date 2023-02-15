using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionICR.Data
{
    public class BoothResponse
    {
        public int PoolingBoothID { get; set; }
        public int LGAID { get; set; }
        public int StateID { get; set; }

        public int WardID { get; set; }
        public string PoolingBoothCode { get; set; }
        public string PoolingBoothName { get; set; }
        public string PoolingBoothAddress { get; set; }
    }
}