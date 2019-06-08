using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsidio
{
    public class Postulante
    {
        private string _run_postulante;

        public string Run_Postulante
        {
            get { return _run_postulante; }
            set { _run_postulante = value; }
        }

        private string _primer_nombre;

        public string Primer_Nombre
        {
            get { return _primer_nombre; }
            set { _primer_nombre = value; }
        }

        private string _segundo_nombre;

        public string Segundo_Nombre
        {
            get { return _segundo_nombre; }
            set { _segundo_nombre = value; }
        }

        private string _apellido_paterno;

        public string Apellido_Paterno
        {
            get { return _apellido_paterno; }
            set { _apellido_paterno = value; }
        }

        private string _apellido_materno;

        public string Apellido_Materno
        {
            get { return _apellido_materno; }
            set { _apellido_materno = value; }
        }

       //telefono y direccion?



    }
}
