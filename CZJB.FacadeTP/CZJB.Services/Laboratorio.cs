﻿using CZJB.Dto;
using CZJB.SQLDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.Services
{
    public class Laboratorio
    {
        public void RealizarAnalisisDeSangre(User user)
        {
            new LabContext().Add(new LabAppointment()
            {
                ScheduleDate = DateTime.Now.AddDays(10),
                UserId = user.Id,
            });

            Console.WriteLine("Programando análisis de sangre para dentro de 10 dias...");
        }
    }
}
