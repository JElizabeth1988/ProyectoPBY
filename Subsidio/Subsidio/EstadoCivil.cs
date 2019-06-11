using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class EstadoCivil
    {
        //Crear objeto de la Bdd
        private SubsidioEntities bdd = new SubsidioEntities();

        public int Id_Estado_Civil { get; set; }
        public string Descripcion { get; set; }
        
        public EstadoCivil()
        {

        }

        public bool Read()
        {
            try
            {
               ESTADO_CIVIL ecivil = bdd.
                    ESTADO_CIVIL.First(a => a.ID_ESTADO_CIVIL == Id_Estado_Civil);
                Descripcion = ecivil.DESCRIPCION;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
