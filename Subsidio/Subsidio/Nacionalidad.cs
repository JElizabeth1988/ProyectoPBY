using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;

namespace BibliotecaNegocio
{
    public class Nacionalidad
    {
        //Crear objeto de la Bdd
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

        public int Id_Nacionalidad { get; set; }

        public string Descripcion { get; set; }

        public Nacionalidad()
        {

        }

        public bool Read()
        {
            try
            {
                NACIONALIDAD nac = bdd.
                     NACIONALIDAD.First(a => a.ID_NACIONALIDAD == Id_Nacionalidad);
                Descripcion = nac.DESCRIPCION;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Nacionalidad> ReadAll()
        {
            try
            {
                List<Nacionalidad> lista = new List<Nacionalidad>();
                var lista_nac_bdd = bdd.NACIONALIDAD.ToList();
                foreach (NACIONALIDAD item in lista_nac_bdd)
                {
                    Nacionalidad na = new Nacionalidad();
                    na.Id_Nacionalidad = item.ID_NACIONALIDAD;//number no los toma el int
                    na.Descripcion = item.DESCRIPCION;
                    lista.Add(na);
                }
                return lista;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
