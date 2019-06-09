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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para RegistroPostulante.xaml
    /// </summary>
    public partial class RegistroPostulante : MetroWindow
    {
        public RegistroPostulante()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ListadoPostulante list = new ListadoPostulante();
            list.Show();
        }

        private void btnPuntaje_Click(object sender, RoutedEventArgs e)
        {
            RevisionPostulante rev = new RevisionPostulante();
            rev.Show();
        }
    }
}
