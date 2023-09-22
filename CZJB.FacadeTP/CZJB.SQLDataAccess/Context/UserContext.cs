using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZJB.Dto;

namespace CZJB.SQLDataAccess.Context
{
    public class UsersContext
    {
        public IList<User> GetAll()
        {
            string query = $"SELECT * FROM [User]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadUsers(table);
            }
        }

        public User GetById(int id)
        {
            string query = $"SELECT * FROM [User] WHERE Id = @Id";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("Id", id));

                var table = DA.Read(query, sqlParameters);
                return ReadUsers(table).First();
            }
        }

        public IList<User> ReadUsers(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<User> Users = new List<User>();

                foreach (DataRow item in table.Rows)
                {
                    Users.Add(MapUser(item));
                }

                return Users;
            }
            else
            {
                return null;
            }
        }

        public void Add(User user)
        {
            var commands = new List<SqlCommand>();
            string query = $"INSERT INTO User ([Name], [LastName]) VALUES (@Name, @LastName);";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("Name", user.Name));
                sqlParameters.Add(SqlHelper.CreateParameter("LastName", user.LastName));

                commands.Add(DA.CreateCommand(query, sqlParameters));

                DA.InsertAllCommands(commands);
            }
        }

        public User MapUser(DataRow dataRow)
        {
            return new User()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                Name = dataRow["Name"].ToString(),
                LastName = dataRow["LastName"].ToString()
            };
        }
    }
}
