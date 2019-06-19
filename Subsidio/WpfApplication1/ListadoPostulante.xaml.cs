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
    /// Lógica de interacción para ListadoPostulante.xaml
    /// </summary>
    public partial class ListadoPostulante : MetroWindow
    {
        OracleConnection conn = null;
        public ListadoPostulante()
        {
            abrirConexion();
            InitializeComponent();
        }

        private void abrirConexion()
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EntitiesSubsidio"].ConnectionString;
            conn = new OracleConnection("Data Source=localhost:1521/XE;User Id=SUBSIDIO;Password=SUBSIDIO");

                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexión" + ex.Message);
                Logger.Mensaje(ex.Message);

            }
        }

        private void btnListado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Postulante pos = new Postulante();
                dgvLista.ItemsSource = pos.ReadAll2();
                dgvLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                Logger.Mensaje(ex.Message);
            }
        }

        private void dgvLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("FN_LISTAR",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<Postulante> lista = new List<Postulante>();

                OracleParameter output = cmd.Parameters.Add("L_CURSOR",OracleDbType.RefCursor); //copia cursor (como %rowtype)
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Postulante pos = new Postulante();
                    pos.RUN_POSTULANTE = reader.GetString(0);
                    pos.NOMBRE = reader.GetString(1);
                    pos.APELLIDO_PATERNO= reader.GetString(2);
                    pos.APELLIDO_MATERNO = reader.GetString(3);
                    pos.FECHA_NACIMIENTO = reader.GetDateTime(4);
                    pos.MONTO_AHORRO = reader.GetInt32(5);
                    //pos.PUEBLO_ORIGINARIO = reader.GetString(6);
                    pos.CARGAS_FAMILIARES = reader.GetInt32(7);
                    pos.ID_NACIONALIDAD= reader.GetInt32(8);
                    pos.ID_ESTADO_CIVIL = reader.GetInt32(9);
                    pos.ID_GENERO = reader.GetInt32(10);
                    pos.ID_REGION = reader.GetInt32(11);
                    pos.ID_RECEPTOR = reader.GetInt32(12);
                    pos.ID_TITULO = reader.GetInt32(13);

                    lista.Add(pos);

                }
                dgvLista.ItemsSource = lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar Carga de datos");
                Logger.Mensaje(ex.Message);
            }
        }
    }
}
