using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    public class EstadoCivil
    {
        private int _id_estado_civil;

        public int Id_Estado_Civil
        {
            get { return _id_estado_civil; }
            set { _id_estado_civil = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }

        }

        public EstadoCivil()
        {

        }


    }
}
