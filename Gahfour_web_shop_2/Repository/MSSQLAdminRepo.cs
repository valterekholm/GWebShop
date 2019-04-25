using Dapper;
using Gahfour_web_shop_2.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Gahfour_web_shop_2.Repository
{
    public class MSSQLAdminRepo : IAdminRepo
    {
        private readonly IConfiguration _config;

        public MSSQLAdminRepo(IConfiguration configuration)
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

        public int adminCount()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT COUNT(*) FROM [user] WHERE [user].is_admin = 1";
                conn.Open();
                IEnumerable<int> result = conn.Query<int>(sQuery);
                return result.FirstOrDefault();
            }
        }

        public bool registerUser(User user)
        {
            string sQuery = "SELECT COUNT(*) FROM [user] WHERE [user].email = '" + user.Email + "'";

            using (IDbConnection conn = Connection)
            {
                conn.Open();
                IEnumerable<int> result = conn.Query<int>(sQuery);
                if (result.FirstOrDefault() > 0)
                {
                    throw new Exception("Email allready registered");
                }
            }
            int isFirstAdmin = adminCount() == 0 ? 1 : 0;


            string password = GeneratePassword(60, false, true, true, true);

            sQuery = "INSERT INTO [user] (email, name, password, is_admin) VALUES ('" + user.Email + "','" + user.Name + "','" + password + "'," + isFirstAdmin + ")";

            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var affectedRows = conn.Execute(sQuery);
                if (affectedRows > 0)
                {
                    return true;
                }
                throw new Exception("Nothing was saved");
            }
        }

        public int userCount()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT COUNT(*) FROM user";
                conn.Open();
                IEnumerable<int> result = conn.Query<int>(sQuery);
                return result.FirstOrDefault();
            }
        }

        public string GeneratePassword(int length, bool RequireNonAlphanumeric, bool RequireDigit, bool RequireLowercase, bool RequireUppercase)
        {
            /*var options = _userManager.Options.Password;

            int length = options.RequiredLength*/


            System.Text.StringBuilder password = new System.Text.StringBuilder();
            Random random = new Random();

            bool digit=RequireDigit, lowercase=RequireLowercase, uppercase=RequireUppercase, nonAlphanumeric=RequireNonAlphanumeric;

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }

    }
}
