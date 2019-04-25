using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Gahfour_web_shop_2.Models;
using Dapper;

namespace Gahfour_web_shop_2.Repository
{
    public class MSSQLSettingsRepo : ISettingsRepo
    {
        private readonly IConfiguration _config;

        public MSSQLSettingsRepo(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("ConnectionString1"));
            }
        }

        public string getCurrency()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT currency FROM settings";
                conn.Open();
                var result = conn.Query<Settings>(sQuery);
                Settings first = result.FirstOrDefault();
                return first.Currency;
            }
        }

        public bool useTableGrid()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT use_table_grid FROM settings";
                conn.Open();
                //var result = await conn.QueryAsync<Item>(sQuery, new { ID = id });
                var result = conn.Query<Settings>(sQuery);
                Settings first = result.FirstOrDefault();
                return first.Use_table_grid;
            }
        }
    }
}
