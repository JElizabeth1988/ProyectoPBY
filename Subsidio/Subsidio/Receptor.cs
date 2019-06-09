using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    public class Receptor
    {
        private int _id_receptor;

        public int Id_Receptor
        {
            get { return _id_receptor; }
            set { _id_receptor = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }


        public Receptor()
        {

        }

    }
}
