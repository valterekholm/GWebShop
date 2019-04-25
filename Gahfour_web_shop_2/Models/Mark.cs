using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gahfour_web_shop_2.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Name { get; set; }
        public string Banner_Img { get; set; }
    }
}
