using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

namespace BibliotecaNegocio
{
    public class EstadoCivil
    {
        //Crear objeto de la Bdd
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

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

        public List<EstadoCivil> ReadAll()
        {
            try
            {
                List<EstadoCivil> lista = new List<EstadoCivil>();
                var lista_ecivil_bdd = bdd.ESTADO_CIVIL.ToList();
                foreach (BibliotecaControlador.ESTADO_CIVIL item in lista_ecivil_bdd)
                {
                    EstadoCivil est = new EstadoCivil();
                    est.Id_Estado_Civil = item.ID_ESTADO_CIVIL;
                    est.Descripcion = item.DESCRIPCION;
                    lista.Add(est);
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
