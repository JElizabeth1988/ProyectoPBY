using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    public class Titulo
    {
        private int _id_titulo;

        public int Id_Titulo
        {
            get { return _id_titulo; }
            set { _id_titulo = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }

        }

        public Titulo()
        {

        }
    }
}
