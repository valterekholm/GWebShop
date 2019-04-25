using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gahfour_web_shop_2.Models;

namespace Gahfour_web_shop_2.Repository
{
    interface IAPIManager
    {
        int isApikeyAlreadyGenerated(int UserID);

        int GenerateandSaveToken(APIManager APIManagerTB);

        APIManager GetApiDetailsbyUserID(int UserID);

        int DeactivateService(int UserID);

        int ReactivateService(int UserID);
    }
}
