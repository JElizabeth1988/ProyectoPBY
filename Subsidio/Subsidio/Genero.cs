using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;

namespace BibliotecaNegocio
{
    public class Genero
    {
        //Crear objeto de la Bdd
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

        public decimal Id_Genero { get; set; }
        public string Descripcion { get; set; }

        public Genero()
        {

        }

        public bool Read()
        {
            try
            {
                GENERO sexo = bdd.
                     GENERO.First(a => a.ID_GENERO == Id_Genero);
                Descripcion = sexo.DESCRIPCION;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Genero> ReadAll()
        {
            try
            {
                List<Genero> lista = new List<Genero>();
                var lista_sexo_bdd = bdd.GENERO.ToList();
                foreach (GENERO item in lista_sexo_bdd)
                {
                    Genero ge = new Genero();
                    ge.Id_Genero = item.ID_GENERO;//number no los toma el int
                    ge.Descripcion = item.DESCRIPCION;
                    lista.Add(ge);
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
