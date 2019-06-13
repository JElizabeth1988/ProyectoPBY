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
            string connectionString = ConfigurationManager.ConnectionStrings["EntitiesSubsidio"].ConnectionString;
            conn = new OracleConnection(connectionString);

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
                    pos.Run_Postulante = reader.GetString(0);
                    pos.Nombre = reader.GetString(1);
                    pos.Apellido_Paterno = reader.GetString(2);
                    pos.Apellido_Materno = reader.GetString(3);
                    pos.Fecha_Nacimiento = reader.GetDateTime(4);
                    pos.Monto_Ahorro = reader.GetInt32(5);
                    pos.Pueblo_Originario = reader.GetChar(6);
                    pos.Cargas_Familiares = reader.GetInt32(7);
                    pos.Id_Nacionalidad = reader.GetInt32(8);
                    pos.Id_Estado_Civil = reader.GetInt32(9);
                    pos.Id_Genero = reader.GetInt32(10);
                    pos.Id_Region = reader.GetInt32(11);
                    pos.Id_Receptor = reader.GetInt32(12);
                    pos.Id_Titulo = reader.GetInt32(13);

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
