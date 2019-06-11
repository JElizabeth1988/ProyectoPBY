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
using BibliotecaDALC;
using BibliotecaNegocio;

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
            rbSi.IsChecked = true;

            //CB Género
            foreach (Genero item in new Genero().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_Genero;
                cb.descripcion = item.Descripcion;
                cbGenero.Items.Add(cb);
            }

            //CB ESTADO CIVIL
            foreach (EstadoCivil item in new EstadoCivil().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_Estado_Civil;
                cb.descripcion = item.Descripcion;
                cbEstadoCivil.Items.Add(cb);
            }

            //CB NACIONALIDAD
            foreach (Nacionalidad item in new Nacionalidad().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_Nacionalidad ;
                cb.descripcion = item.Descripcion;
                cbNacionalidad.Items.Add(cb);
            }

            //CB CARGAS???? mejor dejarlo como textBox
            cbNumCargas.Items.Add("0-2");
            cbNumCargas.Items.Add("2-4");
            cbNumCargas.Items.Add("Más de 4");

            //CB TITULO
            foreach (Titulo item in new Titulo().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_Titulo;
                cb.descripcion = item.Descripcion;
                cbTitulo.Items.Add(cb);
            }

            //CB REGION
            foreach (Region item in new Region().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_Region;
                cb.descripcion = item.Nombre;
                cbRegion.Items.Add(cb);
            }

            //CB RECEPTOR
            foreach (Receptor item in new Receptor().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_Receptor;
                cb.descripcion = item.Nombre;
                cbReceptor.Items.Add(cb);
            }
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

        /*private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Postulante pos = new Postulante();
                pos.Run_Postulante = txtRut.Text;
                pos.Nombre = txtNombre.Text;
                pos.Apellido_Paterno = txtApPaterno.Text;
                pos.Apellido_Materno = txtApMaterno.Text;
                pos.Fecha_Nacimiento = dpFechaNac.SelectedDate.Value;
                pos.Monto_Ahorro = int.Parse(txtMontoAhorro.Text);
                pos.Pueblo_Originario = rbSi.IsChecked == true ? 'S' : 'N';
                pos.Cargas_Familiares = int.Parse(cbNumCargas.SelectedItem.ToString());

                //CLAVES FORANEAS
                /*pos.Id_Nacionalidad =;
                pos.Id_Estado_Civil =;
                pos.Id_Genero =;
                pos.Id_Region =;
                pos.Id_Region =;
                pos.Id_Receptor =;
                pos.Id_Titulo =;  

               // Conexion cone = new Conexion();
                bool resp = cone.Grabar(pos);
                MessageBox.Show(resp ? "Grabo" : "No Grabo");
            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(ex.Message));

            }
        }*/


        //añadir formato al rut

        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text.Length >= 7 && txtRut.Text.Length <= 8)
            {
                string v = new Verificar().ValidarRut(txtRut.Text);
                txtDvRut.Text = v;
                try
                {
                    string rutSinFormato = txtRut.Text;

                    //si el rut ingresado tiene "." o "," o "-" son ratirados para realizar la formula 
                    rutSinFormato = rutSinFormato.Replace(",", "");
                    rutSinFormato = rutSinFormato.Replace(".", "");
                    rutSinFormato = rutSinFormato.Replace("-", "");
                    string rutFormateado = String.Empty;

                    //obtengo la parte numerica del RUT
                    //string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);
                    string rutTemporal = rutSinFormato;
                    //obtengo el Digito Verificador del RUT
                    //string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

                    Int64 rut;

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rut))
                    {
                        rut = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rut.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        // rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }

                    //se pasa a mayuscula si tiene letra k
                    rutFormateado = rutFormateado.ToUpper();

                    //la salida esperada para el ejemplo es 99.999.999-K
                    txtRut.Text = rutFormateado;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtRut.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
