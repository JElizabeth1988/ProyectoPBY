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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para ListadoPostulante.xaml
    /// </summary>
    public partial class ListadoPostulante : MetroWindow
    {
        
        public ListadoPostulante()
        {
            InitializeComponent();
        }

        private void btnListado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Postulante pos = new Postulante();
                dgvLista.ItemsSource = pos.ReadAll();//en proceso read all 2
                dgvLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                Logger.Mensaje(ex.Message);
            }
        }
    }
}
