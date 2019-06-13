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
                cb.id = item.Id_Nacionalidad;
                cb.descripcion = item.Descripcion;
                cbNacionalidad.Items.Add(cb);
            }


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

            cbEstadoCivil.SelectedIndex = 0;
            cbGenero.SelectedIndex = 0;
            cbNacionalidad.SelectedIndex = 0;
            cbReceptor.SelectedIndex = 0;
            cbRegion.SelectedIndex = 0;
            cbTitulo.SelectedIndex = 0;
            txtNumCargas.Text = "0";
            txtMontoAhorro.Text = "0";
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

                string run_postulante = txtRut.Text + "-" + txtDvRut.Text;
                if (run_postulante.Length == 11)
                {
                    run_postulante = "0" + txtRut.Text + "-" + txtDvRut.Text;
                }
                string nombre = txtNombre.Text;
                string apellido_paterno = txtApPaterno.Text;
                string apellido_materno = txtApMaterno.Text;
                DateTime fecha_nacimiento = dpFechaNac.SelectedDate.Value;
                //int monto_ahorro = int.Parse(txtMontoAhorro.Text);
                int monto_ahorro = 0;
                if (int.TryParse(txtMontoAhorro.Text, out monto_ahorro))
                {

                }
                else
                {
                    /*await this.ShowMessageAsync("Mensaje:",
                     string.Format("Ingrese un valor numérico"));
                    txtNumCargas.Focus();*/
                    return;
                }
                string pueblo_originario = rbSi.IsChecked == true ? "S" : "N";
                //int cargas_familiares = int.Parse(txtNumCargas.Text);
                int cargas_familiares = 0;
                if (int.TryParse(txtNumCargas.Text, out cargas_familiares))
                {

                }
                else
                {
                    /*await this.ShowMessageAsync("Mensaje:",
                     string.Format("Ingrese un valor numérico"));
                    txtNumCargas.Focus();*/
                    return;
                }
                decimal id_nacionalidad = ((comboBoxItem)cbNacionalidad.SelectedItem).id;
                decimal id_estado_civil = ((comboBoxItem)cbEstadoCivil.SelectedItem).id;
                decimal id_genero = ((comboBoxItem)cbGenero.SelectedItem).id;
                decimal id_region = ((comboBoxItem)cbRegion.SelectedItem).id;
                decimal id_receptor = ((comboBoxItem)cbReceptor.SelectedItem).id;
                decimal id_titulo = ((comboBoxItem)cbReceptor.SelectedItem).id;

                Postulante pos = new Postulante()
                {
                    Run_Postulante = run_postulante,
                    Nombre = nombre,
                    Apellido_Paterno = apellido_paterno,
                    Apellido_Materno = apellido_materno,
                    Fecha_Nacimiento = fecha_nacimiento,
                    Monto_Ahorro = monto_ahorro,
                    Pueblo_Originario = pueblo_originario,
                    Cargas_Familiares = cargas_familiares,
                    Id_Nacionalidad = id_nacionalidad,
                    Id_Estado_Civil=id_estado_civil,
                    Id_Genero = id_genero,
                    Id_Region = id_region,
                    Id_Receptor = id_receptor,
                    Id_Titulo = id_titulo
                };

                bool resp = pos.Grabar();
                await this.ShowMessageAsync("Mensaje:",
                           string.Format(resp ? "Guardado" : "No guardado"));
                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    Errores de = pos.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje1:",
                        string.Format(li));
                }


                //-----------------------------------------------------------------------------------------------


            }
           
            catch (ArgumentException ex) //catch excepciones hechas por el usuario
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(ex.Message));
            }
            catch (Exception ex)
            {
                
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                Logger.Mensaje(ex.Message);

            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


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
        

    }
}
