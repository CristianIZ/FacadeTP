using CZJB.Dto;
using CZJB.SQLDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.Services
{
    public class Radiologia
    {
        public void RealizarRadiografia(User user)
        {
            new RadContext().Add(new RadAppointment()
            {
                UserId = user.Id,
                ScheduleDate = DateTime.Now.AddDays(10),
            });

            Console.WriteLine("Programando radiografía para dentro de 10 dias...");
        }
    }
}
