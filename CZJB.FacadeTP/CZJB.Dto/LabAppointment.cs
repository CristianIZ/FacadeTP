using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.Dto
{
    public class LabAppointment
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int UserId { get; set; }
    }
}
