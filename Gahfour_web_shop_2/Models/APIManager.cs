using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gahfour_web_shop_2.Models
{
    public class APIManager
    {
        public int Id { get; set; }
        public string Api_Key { get; set; }
        public DateTime Created_On { get; set; }
        public int UserId { get; set; }
        public bool Key_Status { get; set; }
    }
}
