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
            conn = new OracleConnection("Data Source = localhost:1521 / XE; User Id = SUBSIDIO; Password = SUBSIDIO");

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

        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Postulante pos = new Postulante();

                //FN PUNTAJE CARGA----------------------------------------------------------
                OracleCommand cmd = new OracleCommand("FN_PUNTAJE_CARG_FAM", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro de salida (out)
                //La variable v_punt guarda lo que retorna la función
                OracleParameter v_punt = cmd.Parameters.Add("v_punt", OracleDbType.Int32);
                v_punt.Direction = ParameterDirection.ReturnValue;

                //parametros de entrada (in)
                //la variable RUT es de entrada 
                OracleParameter rut = cmd.Parameters.Add("rut", OracleDbType.Varchar2);
                rut.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                rut.Value = txtRut.Text;//se le carga un valor desde caja texto

                cmd.Parameters.Add(rut);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtCargas.Text = cmd.Parameters["v_punt"].Value.ToString();//Se ejecuta y se muestra



                //FN PUNTAJE ESTADO------------------------------------------------------- 
                cmd = new OracleCommand("FN_PUNTAJE_CIVIL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametro de salida (out)
                OracleParameter v_puntaje = cmd.Parameters.Add("v_puntaje", OracleDbType.Int32);
                v_puntaje.Direction = ParameterDirection.ReturnValue;

                //Parametros de entrada (in)
                OracleParameter v_rut = cmd.Parameters.Add("rut", OracleDbType.Varchar2);
                v_rut.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                v_rut.Value = txtRut.Text;//se le carga un valor desde caja texto


                cmd.Parameters.Add(v_rut);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtEstadoCivil.Text = cmd.Parameters["v_puntaje"].Value.ToString();//Se ejecuta y se muestra



                //FN PUNTAJE AHORRO, COMO LLAMO AL MONTO DE ESE POSTULANTE?------------------------
                cmd = new OracleCommand("FN_AHORRO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametro de salida (out)
                OracleParameter punt = cmd.Parameters.Add("v_puntaje", OracleDbType.Int32);
                punt.Direction = ParameterDirection.ReturnValue;

                //Parametros de entrada (in)
                OracleParameter monto = cmd.Parameters.Add("monto", OracleDbType.Int32);
                monto.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                monto.Value = pos.MONTO_AHORRO;//se le carga un valor desde caja texto


                cmd.Parameters.Add(monto);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtAhorro.Text = cmd.Parameters["v_puntaje"].Value.ToString();//Se ejecuta y se muestra

                //FN PUNTAJE PUEBLO---------------------------------------------------
                cmd = new OracleCommand("FN_PUEBLO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //salida
                OracleParameter puntajes = cmd.Parameters.Add("v_puntaje", OracleDbType.Int32);
                puntajes.Direction = ParameterDirection.ReturnValue;

                //Parametros de entrada (in)
                OracleParameter ruts = cmd.Parameters.Add("rut", OracleDbType.Varchar2);
                ruts.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                ruts.Value = txtRut.Text;//se le carga un valor desde caja texto


                cmd.Parameters.Add(ruts);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtPueblo.Text = cmd.Parameters["v_puntaje"].Value.ToString();//Se ejecuta y se muestra

                //FN PUNTAJE TITULO
                cmd = new OracleCommand("FN_TITULO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("id_tit", OracleDbType.Int32).Value = pos.ID_TITULO;

                // salida
                OracleParameter valor = cmd.Parameters.Add("v_puntaje", OracleDbType.Int32);
                valor.Direction = ParameterDirection.ReturnValue;

                //Parametros de entrada (in)
                OracleParameter titulo = cmd.Parameters.Add("id_tit", OracleDbType.Int32);
                titulo.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                titulo.Value = pos.ID_TITULO;//se le carga un valor desde caja texto


                cmd.Parameters.Add(titulo);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtTitulo.Text = cmd.Parameters["v_puntaje"].Value.ToString();//Se ejecuta y se muestra

                //FN PUNTAJE EDAD
                cmd = new OracleCommand("FN_EDAD", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //salida
                OracleParameter p = cmd.Parameters.Add("v_puntaje", OracleDbType.Int32);
                p.Direction = ParameterDirection.ReturnValue;

                //Parametros de entrada (in)
                OracleParameter fecha = cmd.Parameters.Add("fecha", OracleDbType.Date);
                fecha.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                fecha.Value = pos.FECHA_NACIMIENTO;//se le carga un valor desde caja texto

                cmd.Parameters.Add(fecha);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtEdad.Text = cmd.Parameters["v_puntaje"].Value.ToString();//Se ejecuta y se muestra




                //FN PUNTAJE ZONA EXTREMA--
                cmd = new OracleCommand("FN_PORC_REGION", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //salida
                OracleParameter porcentaje = cmd.Parameters.Add("v_porcentaje", OracleDbType.Int32);
                porcentaje.Direction = ParameterDirection.ReturnValue;

                //Parametros de entrada (in)
                OracleParameter region = cmd.Parameters.Add("id_region", OracleDbType.Date);
                region.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                region.Value = pos.ID_REGION;//se le carga un valor desde caja texto


                cmd.Parameters.Add(region);//agrego el parámetro de entrada al comando
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtEdad.Text = cmd.Parameters["v_porcentaje"].Value.ToString();//Se ejecuta y se muestra

                //TOTAL
                cmd = new OracleCommand("FN_TOTAL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //SALIDA
                OracleParameter p_total = cmd.Parameters.Add("v_puntaje", OracleDbType.Int32);
                p_total.Direction = ParameterDirection.ReturnValue;

                //ENTRADA------------------
                //FECHA
                OracleParameter fec = cmd.Parameters.Add("fecha", OracleDbType.Date);
                fec.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                fec.Value = pos.FECHA_NACIMIENTO;

                //MONTO
                OracleParameter mont = cmd.Parameters.Add("monto", OracleDbType.Int32);
                mont.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                mont.Value = pos.MONTO_AHORRO;//se le carga un valor desde caja texto

                //TITULO
                OracleParameter tit = cmd.Parameters.Add("id_tit", OracleDbType.Int32);
                tit.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                tit.Value = pos.ID_TITULO;//se le carga un valor desde caja texto

                //REGION
                OracleParameter reg = cmd.Parameters.Add("id_region", OracleDbType.Date);
                reg.Direction = ParameterDirection.Input;//contiene el parametro de entrada
                reg.Value = pos.ID_REGION;//se le carga un valor desde caja texto


                cmd.Parameters.Add(fec);//agrego el parámetro de entrada al comand
                cmd.Parameters.Add(mont);
                cmd.Parameters.Add(tit);
                cmd.Parameters.Add(reg);
                cmd.ExecuteNonQuery();//se ejecuta la función
                txtCalculo.Text = cmd.Parameters["v_puntaje"].Value.ToString();//Se ejecuta y se muestra



            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                         string.Format("Error al cargar datos"));
                Logger.Mensaje(ex.Message);
            }
            //conn.Close();

        }
    }
}
