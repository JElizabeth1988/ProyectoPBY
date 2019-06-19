using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;

namespace BibliotecaNegocio
{
    public class PuebloOriginario
    {
        //Crear objeto de la Bdd
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

        public int id_pueblo { get; set; }
        public string Nombre { get; set; }

        public PuebloOriginario()
        {

        }

        public bool Read()
        {
            try
            {
                PUEBLO_ORIGINARIO pu = bdd.
                     PUEBLO_ORIGINARIO.First(a => a.ID_PUEBLO == id_pueblo);
                Nombre = pu.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PuebloOriginario> ReadAll()
        {
            try
            {
                List<PuebloOriginario> lista = new List<PuebloOriginario>();
                var lista_pu_bdd = bdd.PUEBLO_ORIGINARIO.ToList();
                foreach (PUEBLO_ORIGINARIO item in lista_pu_bdd)
                {
                    PuebloOriginario pue = new PuebloOriginario();
                    pue.id_pueblo = item.ID_PUEBLO;
                    pue.Nombre = item.NOMBRE;
                    lista.Add(pue);
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
