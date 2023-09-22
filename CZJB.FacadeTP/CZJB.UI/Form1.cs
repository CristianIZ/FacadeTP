using CZJB.Dto;
using CZJB.Services;
using CZJB.SQLDataAccess;
using CZJB.SQLDataAccess.Context;
using System.Linq;
using System.Text;

namespace CZJB.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitView();
        }

        private void btnFullExam_Click(object sender, EventArgs e)
        {
            var facade = new FacadeHospital();

            if (cmbPacientes.SelectedItem == null)
            {
                return;
            }

            var user = (User)(cmbPacientes.SelectedItem);
            facade.RealizarExamenCompleto(user);

            InitView();
        }

        private void btnMedicalAppointment_Click(object sender, EventArgs e)
        {
            var facade = new FacadeHospital();

            if (cmbPacientes.SelectedItem == null)
            {
                return;
            }

            var user = (User)(cmbPacientes.SelectedItem);
            facade.ReservarTurnoMedico(user);

            InitView();
        }

        private void InitView()
        {
            var users = new UsersContext().GetAll();

            foreach (var user in users)
            {
                cmbPacientes.Items.Add(user);
            }

            var labAppointments = new LabContext().GetAll();
            var radAppointments = new RadContext().GetAll();
            var appointments = new AppointmentContext().GetAll();

            var sb = new StringBuilder();
            foreach (var user in users)
            {
                sb.AppendLine($"Citas para el usuario {user.Name} {user.LastName}");

                foreach (var appointment in appointments.Where(c => c.UserId == user.Id))
                {
                    sb.AppendLine($"Cita con medico fecha: {appointment.ScheduleDate}");
                }

                foreach (var radAppointment in radAppointments.Where(c => c.UserId == user.Id))
                {
                    sb.AppendLine($"Cita con radiologia fecha: {radAppointment.ScheduleDate}");
                }

                foreach (var labAppointment in labAppointments.Where(c => c.UserId == user.Id))
                {
                    sb.AppendLine($"Cita con laboratorio fecha: {labAppointment.ScheduleDate}");
                }

                sb.AppendLine($"---------------------------");
            }

            txtLog.Text = sb.ToString();
        }
    }
}