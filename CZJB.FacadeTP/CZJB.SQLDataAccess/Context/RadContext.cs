using CZJB.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.SQLDataAccess.Context
{
    public class RadContext
    {
        public IList<RadAppointment> GetAll()
        {
            string query = $"SELECT * FROM [RadAppointment]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadRadAppointments(table);
            }
        }

        public RadAppointment GetById(int id)
        {
            string query = $"SELECT * FROM [RadAppointment] WHERE Id = @Id";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("Id", id));

                var table = DA.Read(query, sqlParameters);
                return ReadRadAppointments(table).First();
            }
        }

        public IList<RadAppointment> ReadRadAppointments(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<RadAppointment> RadAppointments = new List<RadAppointment>();

                foreach (DataRow item in table.Rows)
                {
                    RadAppointments.Add(MapRadAppointment(item));
                }

                return RadAppointments;
            }
            else
            {
                return null;
            }
        }

        public void Add(RadAppointment radAppointment)
        {
            var commands = new List<SqlCommand>();
            string query = $"INSERT INTO RadAppointment ([ScheduleDate], [UserId]) VALUES (@ScheduleDate, @UserId);";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("ScheduleDate", radAppointment.ScheduleDate));
                sqlParameters.Add(SqlHelper.CreateParameter("UserId", radAppointment.UserId));

                commands.Add(DA.CreateCommand(query, sqlParameters));

                DA.InsertAllCommands(commands);
            }
        }

        public RadAppointment MapRadAppointment(DataRow dataRow)
        {
            return new RadAppointment()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                ScheduleDate = Convert.ToDateTime(dataRow["ScheduleDate"].ToString()),
                UserId = Convert.ToInt32(dataRow["UserId"].ToString())
            };
        }
    }
}
