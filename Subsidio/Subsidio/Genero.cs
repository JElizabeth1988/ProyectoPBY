using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsidio
{
    public class Genero
    {
        private int _id_genero;

        public int Id_Genero
        {
            get { return _id_genero; }
            set { _id_genero = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }

        }

        public Genero()
        {

        }
    }
}
