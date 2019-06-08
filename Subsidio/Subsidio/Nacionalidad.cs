using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsidio
{
    public class Nacionalidad
    {
        private int _id_nacionalidad;

        public int Id_Nacionalidad
        {
            get { return _id_nacionalidad; }
            set { _id_nacionalidad = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }

        }

        public Nacionalidad()
        {

        }
    }
}
