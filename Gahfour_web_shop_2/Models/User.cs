using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gahfour_web_shop_2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
