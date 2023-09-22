using CZJB.Dto;
using CZJB.SQLDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.Services
{
    public class ConsultaMedica
    {
        public void RealizarConsulta(User user)
        {
            new AppointmentContext().Add(new Appointment()
            {
                UserId = user.Id,
                ScheduleDate = DateTime.Now.AddDays(10),
            });

            Console.WriteLine("Programando consulta médica para dentro de 10 dias...");
        }
    }
}
