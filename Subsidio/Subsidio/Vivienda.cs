using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;

namespace BibliotecaNegocio
{
    public class Vivienda
    {
        //Crear objeto de la Bdd
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

        public int ID_VIVIENDA { get; set; }
        public string Descripcion { get; set; }


        public Vivienda()
        {

        }

        public bool Read()
        {
            try
            {
                VIVIENDA viv = bdd.
                     VIVIENDA.First(a => a.ID_VIVIENDA == ID_VIVIENDA);
                Descripcion = viv.DESCRIPCION;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Vivienda> ReadAll()
        {
            try
            {
                List<Vivienda> lista = new List<Vivienda>();
                var lista_viv_bdd = bdd.VIVIENDA.ToList();
                foreach (VIVIENDA item in lista_viv_bdd)
                {
                    Vivienda vi = new Vivienda();
                    vi.ID_VIVIENDA = item.ID_VIVIENDA;
                    vi.Descripcion = item.DESCRIPCION;
                    lista.Add(vi);
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
