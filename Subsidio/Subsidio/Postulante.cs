using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class Postulante
    {
        private string _run_postulante;

        public string Run_Postulante
        {
            get { return _run_postulante; }
            set
            {
                if (value != null && value.Length >= 11 && value.Length <= 12)
                {
                    _run_postulante = value;
                }
                else
                {
                    throw new ArgumentException("Campo Rut no puede estar Vacío");
                }

            }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set {
                    if (value != null)
                    {
                        _nombre = value;
                    }
                    else
                    {
                        throw new ArgumentException("Campo Nombre no puede estar Vacío");
                    }
                }
        }


        private string _apellido_paterno;

        public string Apellido_Paterno
        {
            get { return _apellido_paterno; }
            set {
                    if (value != null)
                    {
                        _apellido_paterno = value;
                    }
                    else
                    {
                        throw new ArgumentException("Campo Apellido Paterno no puede estar Vacío");
                    }
                 }
        }

        private string _apellido_materno;

        public string Apellido_Materno
        {
            get { return _apellido_materno; }
            set {
                if (value != null)
                {
                    _apellido_materno = value;
                }
                else
                {
                    throw new ArgumentException("Campo Apellido no puede estar Vacío");
                }

            }
        }

        private DateTime _fecha_Nacimiento;

        public DateTime Fecha_Nacimiento
        {
            get { return _fecha_Nacimiento; }
            set { _fecha_Nacimiento = value; }
        }

        private decimal _monto_ahorro;

        public decimal Monto_Ahorro
        {
            get { return _monto_ahorro; }
            set {
                if (value >=8000000)
                {
                    _monto_ahorro = value;
                }
                else
                {
                    throw new ArgumentException("Monto Ahorro insuficiente");
                }
                 }
        }

        private string _pueblo_originario;

        public string Pueblo_Originario
        {
            get { return _pueblo_originario; }
            set { _pueblo_originario = value; }
        }

        private decimal _cargas_familiares;

        public decimal Cargas_Familiares
        {
            get { return _cargas_familiares; }
            set { _cargas_familiares = value; }
        }

        //Foraneas
        public decimal Id_Nacionalidad { get; set; }
        public decimal Id_Estado_Civil { get; set; }
        public decimal Id_Genero { get; set; }
        public decimal Id_Region { get; set; }
        public decimal Id_Receptor { get; set; }
        public decimal Id_Titulo { get; set; }

        public Postulante()
        {

        }

        //creo un objeto que me permite manipular todo en la BD
        private SubsidioEntities bdd = new SubsidioEntities();

        //MÉTODOS CRUD
        //grabar
        public Boolean Grabar()
        {
            try
            {
                //creo un modelo de la tabla postulante
                POSTULANTE pos = new POSTULANTE();
                CommonBC.Syncronize(this, pos);
                bdd.POSTULANTE.Add(pos);
                bdd.SaveChanges();

                return true;


            }
            catch (Exception ex)
            {

                return false;
               Logger.Mensaje(ex.Message);
            }
        }

        public bool Eliminar()
        {
            try
            {
                    BibliotecaDALC.POSTULANTE pos =
                    //bdd.POSTULANTE.First(po => po.Run_Postulante.Equals(Run_Postulante));
                    bdd.POSTULANTE.Find(Run_Postulante);

                    bdd.POSTULANTE.Remove(pos);
                    bdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
            }
        }

        public bool Buscar()
        {
            try
            {
                BibliotecaDALC.POSTULANTE pos =
                bdd.POSTULANTE.First(po => po.RUN_POSTULANTE.Equals(Run_Postulante));
               
                CommonBC.Syncronize(pos, this);//arregló this

                return true;

            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
            }
        }

        public bool Read()
        {
            try
            {
                POSTULANTE pos = bdd.POSTULANTE.Find(Run_Postulante);
                CommonBC.Syncronize(pos, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Logger.Mensaje(ex.Message);
            }

        }
        public List<Postulante> ReadAll()
        {
            try
            {
                var p = from pos in bdd.POSTULANTE
                        select new Postulante()
                        {
                            Run_Postulante = pos.RUN_POSTULANTE,
                            Nombre = pos.NOMBRE,
                            Apellido_Paterno = pos.APELLIDO_PATERNO,
                            Apellido_Materno = pos.APELLIDO_MATERNO,
                            Fecha_Nacimiento= pos.FECHA_NACIMIENTO,
                            Monto_Ahorro= pos.MONTO_AHORRO,
                            Pueblo_Originario= pos.PUEBLO_ORIGINARIO,//ambos son char????
                            Cargas_Familiares=pos.CARGAS_FAMILIARES,
                            Id_Nacionalidad=pos.ID_NACIONALIDAD,
                            Id_Estado_Civil=pos.ID_ESTADO_CIVIL,
                            Id_Genero=pos.ID_GENERO,
                            Id_Region=pos.ID_REGION,
                            Id_Receptor=pos.ID_RECEPTOR,
                            Id_Titulo=pos.ID_TITULO

              
                        };
                return p.ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<listaPostulantes> ReadAll2()
        {
            try
            {
                var p = from pos in bdd.POSTULANTE
                        join ecivil in bdd.ESTADO_CIVIL
                          on pos.ID_ESTADO_CIVIL equals ecivil.ID_ESTADO_CIVIL
                        join sexo in bdd.GENERO
                          on pos.ID_GENERO equals sexo.ID_GENERO
                        join nac in bdd.NACIONALIDAD
                          on pos.ID_NACIONALIDAD equals nac.ID_NACIONALIDAD
                        join rec in bdd.RECEPTOR
                          on pos.ID_RECEPTOR equals rec.ID_RECEPTOR
                        join reg in bdd.REGION
                          on pos.ID_REGION equals reg.ID_REGION
                        join tit in bdd.TITULO
                          on pos.ID_TITULO equals tit.ID_TITULO
                        select new listaPostulantes()
                        {
                            Rut = pos.RUN_POSTULANTE,
                            Nombre = pos.NOMBRE,
                            Apellido_Paterno = pos.APELLIDO_PATERNO,
                            Apellido_Materno = pos.APELLIDO_MATERNO,
                            Fecha_Nacimiento = pos.FECHA_NACIMIENTO,
                            Monto_Ahorro = pos.MONTO_AHORRO,
                            Pueblo_Originario = pos.PUEBLO_ORIGINARIO,//ambos son char????
                            Cargas_Familiares = pos.CARGAS_FAMILIARES,
                            Nacionalidad = nac.DESCRIPCION,
                            Estado_Civil = ecivil.DESCRIPCION,
                            Genero = sexo.DESCRIPCION,
                            Region = reg.NOMBRE,
                            Receptor = rec.NOMBRE+" "+rec.APELLIDO,
                            Titulo = tit.DESCRIPCION
                        };
                return p.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Modificar
        /*public bool Modificar()
        {
            try
            {
                //creo un modelo de la tabla cliente
                POSTULANTE pos = bdd.POSTULANTE.Find(Run_Postulante);
                CommonBC.Syncronize(this, pos);
                bdd.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }*/




    }
    public class listaPostulantes
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public decimal Monto_Ahorro { get; set; }
        public string Pueblo_Originario { get; set; }
        public decimal Cargas_Familiares { get; set; }
        public string Nacionalidad { get; set; }
        public string Estado_Civil { get; set; }
        public string Genero { get; set; }
        public string Region { get; set; }
        public string Receptor { get; set; }
        public string Titulo { get; set; }

        public listaPostulantes()
        {

        }

    }

    
}
