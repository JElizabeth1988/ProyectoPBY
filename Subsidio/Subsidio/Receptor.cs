using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class Receptor
    {
        //Crear objeto de la Bdd
        private SubsidioEntities bdd = new SubsidioEntities();

        public decimal Id_Receptor { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Receptor()
        {

        }

        public bool Read()
        {
            try
            {
                RECEPTOR rec = bdd.
                     RECEPTOR.First(a => a.ID_RECEPTOR == Id_Receptor);
                Nombre = rec.NOMBRE;
                Apellido = rec.APELLIDO;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Receptor> ReadAll()
        {
            try
            {
                List<Receptor> lista = new List<Receptor>();
                var lista_rec_bdd = bdd.RECEPTOR.ToList();
                foreach (RECEPTOR item in lista_rec_bdd)
                {
                    Receptor re = new Receptor();
                    re.Id_Receptor = item.ID_RECEPTOR;//number no los toma el int
                    re.Nombre = item.NOMBRE;
                    re.Apellido = item.APELLIDO;
                    lista.Add(re);
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
