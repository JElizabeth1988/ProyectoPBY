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
using BibliotecaControlador;
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
            cbGenero.Items.Add("Femenino");
            cbGenero.Items.Add("Masculino");

            //CB ESTADO CIVIL
            cbEstadoCivil.Items.Add("Casado");
            cbEstadoCivil.Items.Add("Conviviente Civil");
            cbEstadoCivil.Items.Add("Soltero");
            cbEstadoCivil.Items.Add("Divorciado");
            cbEstadoCivil.Items.Add("Viudo");

            //CB NACIONALIDAD
            cbNacionalidad.Items.Add("Chilena");
            cbNacionalidad.Items.Add("Peruana");
            cbNacionalidad.Items.Add("Mexicana");
            cbNacionalidad.Items.Add("Argentina");
            cbNacionalidad.Items.Add("Boliviana");
            cbNacionalidad.Items.Add("Haitiana");
            cbNacionalidad.Items.Add("Colombiana");
            cbNacionalidad.Items.Add("Venezolana");
            cbNacionalidad.Items.Add("China");
            cbNacionalidad.Items.Add("Otra");

            //CB CARGAS
            cbNumCargas.Items.Add("0-2");
            cbNumCargas.Items.Add("2-4");
            cbNumCargas.Items.Add("Más de 4");

            //CB TITULO
            cbTitulo.Items.Add("Profesional");
            cbTitulo.Items.Add("Técnico");
            cbTitulo.Items.Add("No Aplica");

            //CB REGION
            cbRegion.Items.Add("ARICA Y PARINACOTA");
            cbRegion.Items.Add("TARAPACÁ");
            cbRegion.Items.Add("ANTOFAGASTA");
            cbRegion.Items.Add("ATACAMA");
            cbRegion.Items.Add("COQUIMBO");
            cbRegion.Items.Add("VALPARAÍSO");
            cbRegion.Items.Add("METROPOLITANA DE SANTIAGO");
            cbRegion.Items.Add("LIBERTADOR GENERAL BDO. O´HIGGINS");
            cbRegion.Items.Add("MAULE");
            cbRegion.Items.Add("ÑUBLE");
            cbRegion.Items.Add("BIOBÍO");
            cbRegion.Items.Add("ARAUCANÍA");
            cbRegion.Items.Add("LOS RÍOS");
            cbRegion.Items.Add("LOS LAGOS");
            cbRegion.Items.Add("AYSÉN DEL GENERAL CARLOS IBAÑEZ DEL CAMPO");
            cbRegion.Items.Add("MAGALLANES Y DE LA ANTARTICA CHILENA");

            //CB RECEPTOR
            cbReceptor.Items.Add("Francisca Morán");
            cbReceptor.Items.Add("Tomás Carjaval");
            cbReceptor.Items.Add("Antonia Ramírez");
            cbReceptor.Items.Add("Armando Cárcamo");
            cbReceptor.Items.Add("Ignacio Méndez");
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

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Postulante pos = new Postulante();
                pos.Run_Postulante = txtRut.Text + "-" + txtDvRut.Text;
                if (pos.Run_Postulante.Length == 11)
                {
                    pos.Run_Postulante = "0" + txtRut.Text + "-" + txtDvRut.Text;
                }
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
                pos.Id_Titulo =;   */

                Conexion cone = new Conexion();
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
        }

        
        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text.Length >= 7 && txtRut.Text.Length <= 8)
            {
                string v = new Verificar().ValidarRut(txtRut.Text);
                 
                txtDvRut.Text= v;
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
    }


}
