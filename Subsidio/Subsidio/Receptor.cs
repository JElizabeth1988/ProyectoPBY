using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsidio
{
    public class Receptor
    {
        private int _id_receptor;

        public int Id_Receptor
        {
            get { return _id_receptor; }
            set { _id_receptor = value; }
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

        public Receptor()
        {

        }

    }
}
