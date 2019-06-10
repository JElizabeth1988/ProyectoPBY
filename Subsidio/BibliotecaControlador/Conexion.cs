using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using BibliotecaNegocio;

namespace BibliotecaControlador
{
    public class Conexion
    {
        private static OracleConnection cone;
        private string cadena = "Data Source=LAPTOP-1ASS00KU;User ID=subsidio;Password=123;";

        public Conexion()
        {
            if (cone == null)
            {
                cone = new OracleConnection(cadena);
            }
        }
        public bool Grabar(Postulante p)
        {
            try
            {
                string sql =
                    "insert into postulante values(@run_postulante,'@nombre','@apellido_paterno',@apellido_materno,'@fecha_nacimiento','@monto_ahorro','@pueblo_originario','@cargas_familiares','@id_nacionalidad','@'id_estado_civil','@id_genero','@id_region','@id_receptor','id_titulo')";
                sql = sql.Replace("@run_pustulante", p.Run_Postulante;
                sql = sql.Replace("@nom", p.Nombre);
                sql = sql.Replace("@apellido_paterno", p.Apellido_Paterno);
                sql = sql.Replace("@apellido_materno", p.Apellido_Materno);
                sql = sql.Replace("@fecha_nacimiento", p.Fecha_Nacimiento.ToString());
                sql = sql.Replace("@monto_ahorro", p.Monto_Ahorro.ToString());
                sql = sql.Replace("@pueblo_originario", p.Pueblo_Originario.ToString());
                sql = sql.Replace("@cargas_familiares", p.Cargas_Familiares.ToString());
                sql = sql.Replace("@id_nacionalidad", p.Id_Nacionalidad.ToString());
                sql = sql.Replace("@id_estado_civil", p.Id_Estado_Civil.ToString());
                sql = sql.Replace("@id_genero", p.Id_Genero.ToString());
                sql = sql.Replace("@id_region", p.Id_Region.ToString());
                sql = sql.Replace("@id_receptor", p.Id_Receptor.ToString());
                sql = sql.Replace("@id_titulo", p.Id_Titulo.ToString());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone;
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;//sirve para procedure
                cone.Open();
                int cant = cmd.ExecuteNonQuery();
                cone.Close();
                return cant > 0;
            }
            catch (Exception ex)
            {
                if (cone.State == System.Data.ConnectionState.Open)
                {
                    cone.Close();
                }
                return false;
            }
        }
    }

}
