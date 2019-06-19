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
        OracleConnection conn = null;
        public RevisionPostulante()
        {
            InitializeComponent();
            abrirConexion();
        }

        private void abrirConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EntitiesSubsidio"].ConnectionString;
            conn = new OracleConnection("Data Source=XE; User Id=SUBSIDIO;Password=SUBSIDIO;");

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

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //FN PUNTAJE CARGAS FAMILIARES
                listaPostulantes list = new listaPostulantes(); //PARA LLAMAR DATOS ?)
                Postulante pos = new Postulante();

                OracleCommand cmd = new OracleCommand("FN_PUNTAJE_CARG_FAM", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = txtRut.Text;

                //NECESARIO RESCATAR VARIABLE SALIDA?
                /*OracleParameter output = cmd.Parameters.Add("v_punt", OracleDbType.Int32);
                output.Direction = ParameterDirection.ReturnValue;
                string cargas = output.ToString();*/

                string cargas = cmd.ExecuteNonQuery().ToString();

                txtCargas.Text = cargas;

                //FN PUNTAJE ESTADO 
                cmd = new OracleCommand("FN_PUNTAJE_CIVIL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = txtRut.Text;

                string civil = cmd.ExecuteNonQuery().ToString();

                txtEstadoCivil.Text = civil;


                //FN PUNTAJE AHORRO, COMO LLAMO AL MONTO DE ESE POSTULANTE?
                cmd = new OracleCommand("FN_AHORRO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("monto", OracleDbType.Int32).Value = list.Monto_Ahorro;

                string monto = cmd.ExecuteNonQuery().ToString();

                txtAhorro.Text = monto;

                //FN PUNTAJE PUEBLO
                cmd = new OracleCommand("FN_PUEBLO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pueblo", OracleDbType.Varchar2).Value = list.Pueblo;

                string pueblo = cmd.ExecuteNonQuery().ToString();

                txtPueblo.Text = pueblo;

                //FN PUNTAJE TITULO
                cmd = new OracleCommand("FN_TITULO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("id_tit", OracleDbType.Int32).Value = pos.ID_TITULO;

                string titulo = cmd.ExecuteNonQuery().ToString();

                txtTitulo.Text = titulo;

                //FN PUNTAJE EDAD
                cmd = new OracleCommand("FN_EDAD", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("fecha", OracleDbType.Date).Value = list.Fecha_Nacimiento;

                string edad = cmd.ExecuteNonQuery().ToString();

                txtEdad.Text = edad;

                //FN PUNTAJE ZONA EXTREMA--
                cmd = new OracleCommand("FN_PORC_REGION", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("id_region", OracleDbType.Int32).Value = pos.ID_REGION;

                string region = cmd.ExecuteNonQuery().ToString();

                txtRegion.Text = region;

                //TOTAL
                cmd = new OracleCommand("FN_TOTAL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("fecha", OracleDbType.Date).Value = list.Fecha_Nacimiento;
                cmd.Parameters.Add("monto", OracleDbType.Int32).Value = list.Monto_Ahorro;
                cmd.Parameters.Add("pueblo", OracleDbType.Varchar2).Value = list.Pueblo;
                cmd.Parameters.Add("id_tit", OracleDbType.Int32).Value = pos.ID_TITULO;
                cmd.Parameters.Add("id_region", OracleDbType.Int32).Value = pos.ID_REGION;

                string total = cmd.ExecuteNonQuery().ToString();

                txtCalculo.Text = total;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar datos");
                Logger.Mensaje(ex.Message);
            }
            //conn.Close();

        }
    }
}
