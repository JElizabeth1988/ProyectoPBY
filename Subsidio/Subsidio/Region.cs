using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsidio
{
    public class Region
    {
        private int _id_region;

        public int Id_Region
        {
            get { return _id_region; }
            set { _id_region = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Region()
        {

        }
    }
}
