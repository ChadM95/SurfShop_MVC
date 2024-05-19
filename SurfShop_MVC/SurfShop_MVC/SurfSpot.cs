using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfShop_MVC
{
    public class SurfSpot
    {
        public int SurfSpot_id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IdealConditions { get; set; }
    }
}