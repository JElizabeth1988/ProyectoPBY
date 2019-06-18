using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;

namespace BibliotecaNegocio
{
    public class Titulo
    {
        //Crear objeto de la Bdd
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

        public int Id_Titulo { get; set; }

        public string Descripcion { get; set; }

        public Titulo()
        {

        }

        public bool Read()
        {
            try
            {
                TITULO tit= bdd.
                     TITULO.First(a => a.ID_TITULO == Id_Titulo);
                Descripcion = tit.DESCRIPCION;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Titulo> ReadAll()
        {
            try
            {
                List<Titulo> lista = new List<Titulo>();
                var lista_ti_bdd = bdd.TITULO.ToList();
                foreach (TITULO item in lista_ti_bdd)
                {
                    Titulo tt = new Titulo();
                    tt.Id_Titulo = item.ID_TITULO;//number no los toma el int
                    tt.Descripcion = item.DESCRIPCION;
                    lista.Add(tt);
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
