using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Gahfour_web_shop_2.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Gahfour_web_shop_2.Repository
{
    public class MSSQLItemRepo : IItemRepo
    {
        private readonly IConfiguration _config;

        public MSSQLItemRepo(IConfiguration configuration)
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

        public int Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)//async Task<
        {
            //throw new NotImplementedException();

            using(IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM item LEFT JOIN mark ON (mark_id = mark.id) WHERE item.id = @ID";
                conn.Open();
                //var result = await conn.QueryAsync<Item>(sQuery, new { ID = id });
                var result = conn.Query<Item, Mark, Item>(sQuery, (i,m) => {i.Mark = m; return i; }, new { ID = id});
                return result.FirstOrDefault();
            }
        }

        public List<Item> GetItems()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM item LEFT JOIN mark ON (mark_id = mark.id) ORDER BY item.created_date DESC";
                conn.Open();

                //var result = await conn.QueryAsync<Item, Mark, Item>(sQuery, (i, m) => { i.Mark = m; return i; }, new { ID = id });
                //return result.FirstOrDefault();

                var items = conn.Query<Item, Mark, Item>(sQuery, (item, mark) => { item.Mark = mark; return item; }, splitOn: "mark_id").Distinct().ToList();
                return items;
                //return conn.Query<Item>("SELECT * FROM item").ToList();
            }
        }

        public List<Item> GetItemsPage(int page, int perPage)
        {
            if (page < 1) return null;
            if (perPage < 1) return null;
            
            int offset = (page-1) * perPage;
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT item.id, full_name, short_name, mark_id, created_date, image_file, size, size_unit_id, price, description, mark.id, manufacturer_id, mark.name, banner_img, size_unit.id, size_unit.name FROM item LEFT JOIN mark ON (mark_id = mark.id) LEFT JOIN size_unit ON (size_unit_id = size_unit.id) ORDER BY item.id OFFSET " + offset + " ROWS FETCH NEXT " + perPage + " ROWS ONLY";
                //
                //string sQuery = "SELECT item.id, full_name, short_name, mark_id, created_date, image_file FROM item ORDER BY item.created_date DESC OFFSET " + offset + " ROWS FETCH NEXT " + perPage + " ROWS ONLY";
                conn.Open();

                //var result = await conn.QueryAsync<Item, Mark, Item>(sQuery, (i, m) => { i.Mark = m; return i; }, new { ID = id });
                //return result.FirstOrDefault();

                var items = conn.Query<Item, Mark, SizeUnit, Item>(sQuery, (item, mark, sizeunit) => { item.Mark = mark; item.Size_Unit = sizeunit; return item; }).Distinct().ToList();
                //var items = conn.Query<Item>(sQuery);
                return items;
                //return conn.Query<Item>("SELECT * FROM item").ToList();
            }
        }

        public int Insert(Item item)
        {
            throw new NotImplementedException();
        }

        public int Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
