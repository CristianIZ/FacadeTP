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
    public class LabContext
    {
        public IList<LabAppointment> GetAll()
        {
            string query = $"SELECT * FROM [LabAppointment]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadLabAppointments(table);
            }
        }

        public LabAppointment GetById(int id)
        {
            string query = $"SELECT * FROM [LabAppointment] WHERE Id = @Id";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("Id", id));

                var table = DA.Read(query, sqlParameters);
                return ReadLabAppointments(table).First();
            }
        }

        public IList<LabAppointment> ReadLabAppointments(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<LabAppointment> LabAppointments = new List<LabAppointment>();

                foreach (DataRow item in table.Rows)
                {
                    LabAppointments.Add(MapLabAppointment(item));
                }

                return LabAppointments;
            }
            else
            {
                return null;
            }
        }

        public void Add(LabAppointment labAppointment)
        {
            var commands = new List<SqlCommand>();
            string query = $"INSERT INTO LabAppointment ([ScheduleDate], [UserId]) VALUES (@ScheduleDate, @UserId);";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("ScheduleDate", labAppointment.ScheduleDate));
                sqlParameters.Add(SqlHelper.CreateParameter("UserId", labAppointment.UserId));

                commands.Add(DA.CreateCommand(query, sqlParameters));

                DA.InsertAllCommands(commands);
            }
        }

        public LabAppointment MapLabAppointment(DataRow dataRow)
        {
            return new LabAppointment()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                ScheduleDate = Convert.ToDateTime(dataRow["ScheduleDate"].ToString()),
                UserId = Convert.ToInt32(dataRow["UserId"].ToString())
            };
        }
    }
}
