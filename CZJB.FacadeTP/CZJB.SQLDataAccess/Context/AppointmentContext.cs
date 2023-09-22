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
    public class AppointmentContext
    {
        public IList<Appointment> GetAll()
        {
            string query = $"SELECT * FROM [Appointment]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadAppointments(table);
            }
        }

        public Appointment GetById(int id)
        {
            string query = $"SELECT * FROM [Appointment] WHERE Id = @Id";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("Id", id));

                var table = DA.Read(query, sqlParameters);
                return ReadAppointments(table).First();
            }
        }

        public IList<Appointment> ReadAppointments(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<Appointment> Appointments = new List<Appointment>();

                foreach (DataRow item in table.Rows)
                {
                    Appointments.Add(MapAppointment(item));
                }

                return Appointments;
            }
            else
            {
                return null;
            }
        }

        public void Add(Appointment appointment)
        {
            var commands = new List<SqlCommand>();
            string query = $"INSERT INTO Appointment ([ScheduleDate], [UserId]) VALUES (@ScheduleDate, @UserId);";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("ScheduleDate", appointment.ScheduleDate));
                sqlParameters.Add(SqlHelper.CreateParameter("UserId", appointment.UserId));

                commands.Add(DA.CreateCommand(query, sqlParameters));

                DA.InsertAllCommands(commands);
            }
        }

        public Appointment MapAppointment(DataRow dataRow)
        {
            return new Appointment()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                ScheduleDate = Convert.ToDateTime(dataRow["ScheduleDate"].ToString()),
                UserId = Convert.ToInt32(dataRow["UserId"].ToString())
            };
        }
    }
}
