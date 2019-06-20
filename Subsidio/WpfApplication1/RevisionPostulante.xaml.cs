using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using BibliotecaNegocio;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System.Configuration;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para RevisionPostulante.xaml
    /// </summary>
    public partial class RevisionPostulante : MetroWindow
    {
        RegistroPostulante p = new RegistroPostulante();
        OracleConnection conn = null;
        public RevisionPostulante()
        {
            InitializeComponent();
            
            abrirConexion();
        }

        private void abrirConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EntitiesSubsidio"].ConnectionString;
            conn = new OracleConnection("Data Source = localhost:1521 / XE; User Id = SUBSIDIO; Password = SUBSIDIO");

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexión" + ex.Message);
                Logger.Mensaje(ex.Message);

            }
        }

        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                //FN PUNTAJE CARGA----------------------------------------------------------
                OracleCommand cmd = new OracleCommand("SP_PUNTAJES", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                //PARAMETRO DE ENTRADA GENERAL----------------------------------------------
                OracleParameter rut = cmd.Parameters.Add("rut", OracleDbType.Varchar2);
                rut.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                rut.Value = txtRut.Text;//se le carga un valor desde caja texto
                    //--------------------------------------------------------------------------
                    //parametro de salida (out)
                OracleParameter pntj_cargas = cmd.Parameters.Add("pntj_cargas", OracleDbType.Int32);
                pntj_cargas.Direction = ParameterDirection.Output;

                //salida
                OracleParameter pntj_edad = cmd.Parameters.Add("pntj_edad", OracleDbType.Int32);
                pntj_edad.Direction = ParameterDirection.Output;

                //Parametro de salida (out)
                OracleParameter pntj_estado = cmd.Parameters.Add("pntj_estado", OracleDbType.Int32);
                pntj_estado.Direction = ParameterDirection.Output;

                // salida
                OracleParameter pntj_titulo = cmd.Parameters.Add("pntj_titulo", OracleDbType.Int32);
                pntj_titulo.Direction = ParameterDirection.Output;

                //salida
                OracleParameter pntj_region = cmd.Parameters.Add("pntj_region", OracleDbType.Int32);
                pntj_region.Direction = ParameterDirection.Output;

                //salida
                OracleParameter pntj_pueblos = cmd.Parameters.Add("pntj_pueblos", OracleDbType.Int32);
                pntj_pueblos.Direction = ParameterDirection.Output;

                //Parametro de salida (out)
                OracleParameter pntj_ahorro = cmd.Parameters.Add("pntj_ahorro", OracleDbType.Int32);
                pntj_ahorro.Direction = ParameterDirection.Output;

                //SALIDA
                OracleParameter pntj_total = cmd.Parameters.Add("pntj_total", OracleDbType.Int32);
                pntj_total.Direction = ParameterDirection.Output;

               
                 
                cmd.ExecuteNonQuery();//se ejecuta la función   

                //MOSTRAR DATOS
                txtCargas.Text = cmd.Parameters["pntj_cargas"].Value.ToString();//Se ejecuta y se muestra
                txtEstadoCivil.Text = cmd.Parameters["pntj_estado"].Value.ToString();//Se ejecuta y se muestra
                txtAhorro.Text = cmd.Parameters["pntj_ahorro"].Value.ToString();//Se ejecuta y se muestra
                txtPueblo.Text = cmd.Parameters["pntj_pueblos"].Value.ToString();//Se ejecuta y se muestra
                txtTitulo.Text = cmd.Parameters["pntj_titulo"].Value.ToString();//Se ejecuta y se muestra
                txtEdad.Text = cmd.Parameters["pntj_edad"].Value.ToString();//Se ejecuta y se muestra
                txtRegion.Text = cmd.Parameters["pntj_region"].Value.ToString();//Se ejecuta y se muestra
                txtCalculo.Text = cmd.Parameters["pntj_TOTAL"].Value.ToString();//Se ejecuta y se muestra

                conn.Close();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                         string.Format("Error al cargar datos"));
                Logger.Mensaje(ex.Message);
            }
           

        }
    }
}
