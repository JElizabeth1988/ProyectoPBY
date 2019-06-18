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
            OracleCommand cmd = new OracleCommand("FN_cargas_familiares", conn);
            cmd.CommandType = CommandType.StoredProcedure;

        }
    }
}
