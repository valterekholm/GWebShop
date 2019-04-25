using Gahfour_web_shop_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gahfour_web_shop_2.Repository
{
    public interface IAdminRepo
    {
        int userCount();
        int adminCount();
        bool registerUser(User user);
    }
}
