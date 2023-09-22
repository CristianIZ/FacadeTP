using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.Dto
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int UserId { get; set; }
    }
}
