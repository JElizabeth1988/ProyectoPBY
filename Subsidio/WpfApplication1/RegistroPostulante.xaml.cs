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
        Postulante p = new Postulante();
        public RegistroPostulante()
        {
            InitializeComponent();


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

            //CB pueblo Originario
            foreach (PuebloOriginario item in new PuebloOriginario().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.id_pueblo;
                cb.descripcion = item.Nombre;
                cbPueblo.Items.Add(cb);
            }

            //CB pueblo tipo Vivienda
            foreach (Vivienda item in new Vivienda().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.ID_VIVIENDA;
                cb.descripcion = item.Descripcion;
                cbTipoVivienda.Items.Add(cb);
            }


            cbEstadoCivil.SelectedIndex = 0;
            cbGenero.SelectedIndex = 0;
            cbNacionalidad.SelectedIndex = 0;
            cbPueblo.SelectedIndex = 0;
            cbReceptor.SelectedIndex = 0;
            cbRegion.SelectedIndex = 0;
            cbTipoVivienda.SelectedIndex = 0;
            cbTitulo.SelectedIndex = 0;
            dpFechaNac.SelectedDate = DateTime.Now;
            txtNumCargas.Text = "0";
            txtMontoAhorro.Text = "0";
            txtValorVivienda.Text = "0";


        }

        

        private void btnPuntaje_Click(object sender, RoutedEventArgs e)
        {
            RevisionPostulante rev = new RevisionPostulante();
            rev.txtRut.Text = txtRut.Text + '-' + txtDvRut.Text;
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
                        /*await this.ShowMessageAsync("Error:",
                         string.Format("- Ingreso no válido"));
                        txtNumCargas.Focus();*/
                        return;
                    }
                    //int cargas_familiares = int.Parse(txtNumCargas.Text);
                    int cargas_familiares = 0;
                    if (int.TryParse(txtNumCargas.Text, out cargas_familiares))
                    {

                    }
                    else
                    {
                        /*await this.ShowMessageAsync("Error:",
                         string.Format("- Ingreso no válido"));
                        txtNumCargas.Focus();*/
                        return;
                    }
                    int valor_vivienda = 0;
                    if (int.TryParse(txtValorVivienda.Text, out valor_vivienda))
                    {

                    }
                    else
                    {

                        return;
                    }
                    int id_pueblo = ((comboBoxItem)cbPueblo.SelectedItem).id;
                    int id_nacionalidad = ((comboBoxItem)cbNacionalidad.SelectedItem).id;
                    int id_estado_civil = ((comboBoxItem)cbEstadoCivil.SelectedItem).id;
                    int id_genero = ((comboBoxItem)cbGenero.SelectedItem).id;
                    int id_region = ((comboBoxItem)cbRegion.SelectedItem).id;
                    int id_receptor = ((comboBoxItem)cbReceptor.SelectedItem).id;
                    int id_titulo = ((comboBoxItem)cbReceptor.SelectedItem).id;
                    int id_vivienda = ((comboBoxItem)cbTipoVivienda.SelectedItem).id;

                    Postulante pos = new Postulante()
                    {
                        RUN_POSTULANTE = run_postulante,
                        NOMBRE = nombre,
                        APELLIDO_PATERNO = apellido_paterno,
                        APELLIDO_MATERNO = apellido_materno,
                        FECHA_NACIMIENTO = fecha_nacimiento,
                        MONTO_AHORRO = monto_ahorro,
                        VALOR_VIVIENDA = valor_vivienda,
                        CARGAS_FAMILIARES = cargas_familiares,
                        ID_NACIONALIDAD = id_nacionalidad,
                        ID_ESTADO_CIVIL = id_estado_civil,
                        ID_GENERO = id_genero,
                        ID_REGION = id_region,
                        ID_RECEPTOR = id_receptor,
                        ID_TITULO = id_titulo,
                        ID_VIVIENDA = id_vivienda,
                        ID_PUEBLO = id_pueblo
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
                        await this.ShowMessageAsync("Mensaje : ",
                            string.Format(li));
                        

                    btnPuntaje.Visibility = Visibility.Hidden;//Botón puntaje no se ve para q se pueda calcular
                        btnGuardar.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnPuntaje.Visibility = Visibility.Visible;//Botón puntaje se ve para q se pueda calcular
                        btnGuardar.Visibility = Visibility.Hidden;
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

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Postulante p = new Postulante();
                p.RUN_POSTULANTE = txtRut.Text + "-" + txtDvRut.Text;
                bool buscar = p.Buscar();
                if (buscar)
                {
                    txtRut.Text = p.RUN_POSTULANTE.Substring(0, 10);
                    txtDvRut.Text = p.RUN_POSTULANTE.Substring(11, 1);
                    txtRut.IsEnabled = false;
                    txtDvRut.IsEnabled = false;
                    txtNombre.Text = p.NOMBRE;
                    txtApPaterno.Text = p.APELLIDO_PATERNO;
                    txtApMaterno.Text = p.APELLIDO_MATERNO;
                    dpFechaNac.Text = p.FECHA_NACIMIENTO.ToString();
                    txtNumCargas.Text = p.CARGAS_FAMILIARES.ToString();
                    txtMontoAhorro.Text = p.MONTO_AHORRO.ToString();
                    txtValorVivienda.Text = p.VALOR_VIVIENDA.ToString();
                    Genero ge = new Genero();
                    ge.Id_Genero = p.ID_GENERO;
                    ge.Read();
                    cbGenero.Text = ge.Descripcion;
                    EstadoCivil ec = new EstadoCivil();
                    ec.Id_Estado_Civil = p.ID_ESTADO_CIVIL;
                    ec.Read();
                    cbEstadoCivil.Text = ec.Descripcion;
                    Nacionalidad na = new Nacionalidad();
                    na.Id_Nacionalidad = p.ID_NACIONALIDAD;
                    na.Read();
                    cbNacionalidad.Text = na.Descripcion;
                    Titulo ti = new Titulo();
                    ti.Id_Titulo = p.ID_TITULO;
                    ti.Read();
                    cbTitulo.Text = ti.Descripcion;


                    Region rg = new Region();
                    rg.Id_Region = p.ID_REGION;
                    rg.Read();
                    cbRegion.Text = rg.Nombre;
                    Receptor re = new Receptor();
                    re.Id_Receptor = p.ID_RECEPTOR;
                    re.Read();
                    cbReceptor.Text = re.Nombre;

                    Vivienda viv = new Vivienda();
                    viv.ID_VIVIENDA = p.ID_VIVIENDA;
                    viv.Read();
                    cbTipoVivienda.Text = viv.Descripcion;

                    PuebloOriginario pu = new PuebloOriginario();
                    pu.id_pueblo = p.ID_PUEBLO;
                    pu.Read();
                    cbPueblo.Text = pu.Nombre;


                    btnGuardar.Visibility = Visibility.Hidden;
                    await this.ShowMessageAsync("Mensaje:",
                    string.Format("Postulante Existente!"));
                    /*MessageBox.Show("No se encontraron resultados!");*/

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("No se encontraron resultados!"));
                    /*MessageBox.Show("No se encontraron resultados!");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Buscar Información! "));
                /*MessageBox.Show("error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
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

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoPostulante list = new ListadoPostulante();
            list.Show();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtDvRut.Clear();
            txtRut.Clear();
            txtRut.IsEnabled = true;
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
            txtMontoAhorro.Clear();
            txtNumCargas.Text = "0";
            txtValorVivienda.Clear();
            cbEstadoCivil.SelectedIndex = 0;
            cbGenero.SelectedIndex = 0;
            cbNacionalidad.SelectedIndex = 0;
            cbPueblo.SelectedIndex = 0;
            cbReceptor.SelectedIndex = 0;
            cbRegion.SelectedIndex = 0;
            cbTipoVivienda.SelectedIndex = 0;
            cbTitulo.SelectedIndex = 0;
            dpFechaNac.SelectedDate = DateTime.Now;
            txtNumCargas.Text = "0";

            txtRut.Focus();//Mover el cursor a la poscición Rut

            btnGuardar.Visibility = Visibility.Visible;//botón guardar aparece
            txtRut.IsEnabled = true;
        }
    }
}
