using CZJB.Dto;
using CZJB.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.Services
{
    public class FacadeHospital
    {
        private Laboratorio laboratorio;
        private Radiologia radiologia;
        private ConsultaMedica consultaMedica;
        private RepositorioPacientes repositorioPacientes;

        public FacadeHospital()
        {
            laboratorio = new Laboratorio();
            radiologia = new Radiologia();
            consultaMedica = new ConsultaMedica();
            repositorioPacientes = new RepositorioPacientes();
        }

        public void RealizarExamenCompleto(User paciente)
        {
            laboratorio.RealizarAnalisisDeSangre(paciente);
            radiologia.RealizarRadiografia(paciente);
            consultaMedica.RealizarConsulta(paciente);
        }

        public void ReservarTurnoMedico(User paciente)
        {
            laboratorio.RealizarAnalisisDeSangre(paciente);
            consultaMedica.RealizarConsulta(paciente);
        }
    }
}
