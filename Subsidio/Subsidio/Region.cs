using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class Region
    {
        //Crear objeto de la Bdd
        private SubsidioEntities bdd = new SubsidioEntities();

        public decimal Id_Region { get; set; }

        public string Nombre { get; set; }

        public Region()
        {

        }

        public bool Read()
        {
            try
            {
                REGION rg = bdd.
                     REGION.First(a => a.ID_REGION == Id_Region);
                Nombre = rg.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Region> ReadAll()
        {
            try
            {
                List<Region> lista = new List<Region>();
                var lista_re_bdd = bdd.REGION.ToList();
                foreach (REGION item in lista_re_bdd)
                {
                    Region rg = new Region();
                    rg.Id_Region = item.ID_REGION;//number no los toma el int
                    rg.Nombre = item.NOMBRE;
                    lista.Add(rg);
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
