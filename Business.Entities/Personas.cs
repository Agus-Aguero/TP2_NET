using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    
    public class Personas: BusinessEntity
    {
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TipoPersonas _TipoPersona;

        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IDPlan { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public TipoPersonas TipoPersona { get; set; }

        public class TipoPersonas
        {

        }

    }
}