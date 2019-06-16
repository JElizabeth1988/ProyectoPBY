using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;



namespace BibliotecaNegocio
{
    public class Postulante
    {
        Errores err = new Errores();
        public Errores retornar() { return err; }
        private string _run_postulante;

        public string Run_Postulante
        {
            get { return _run_postulante; }
            set
            {
                if (value != "" && value.Length >= 11 && value.Length <= 12)
                {
                    _run_postulante = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Rut no puede estar Vacío");
                }

            }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set {
                    if (value != "")
                    {
                        _nombre = value;
                    }
                    else
                    {
                    //throw new ArgumentException("Campo Nombre no puede estar Vacío");
                    err.AgregarError("- Campo Nombre no puede estar Vacío");
                }
                }
        }


        private string _apellido_paterno;

        public string Apellido_Paterno
        {
            get { return _apellido_paterno; }
            set {
                    if (value != "")
                    {
                        _apellido_paterno = value;
                    }
                    else
                    {
                    //throw new ArgumentException("Campo Apellido Paterno no puede estar Vacío");
                    err.AgregarError("- Campo Apellido Paterno no puede estar Vacío");
                    }
                 }
        }

        private string _apellido_materno;

        public string Apellido_Materno
        {
            get { return _apellido_materno; }
            set {
                if (value != "")
                {
                    _apellido_materno = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Apellido no puede estar Vacío");
                    err.AgregarError("- Campo Apellido Materno no puede estar Vacío");
                }

            }
        }

        private DateTime _fecha_Nacimiento;

        public DateTime Fecha_Nacimiento
        {
            get { return _fecha_Nacimiento; }
            set {
                if (value != null)
                {
                    _fecha_Nacimiento = value;
                }
                else
                {
                    //throw new ArgumentException("Campo fecha no puede estar Vacío");
                    err.AgregarError("- Campo fecha no puede estar Vacío");
                }
            }
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
                    //throw new ArgumentException("Monto Ahorro insuficiente");
                    err.AgregarError("- Monto de Ahorro Insuficiente");
                }
                 }
        }

        private string _pueblo_originario;

        public string Pueblo_Originario
        {
            get { return _pueblo_originario; }
            set {
                if (value != null)
                {
                    _pueblo_originario = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Pueblo Originario no puede estar Vacío");
                    err.AgregarError("-Campo Pueblo Originario no puede estar Vacío");
                }

               }
        }

        private decimal _cargas_familiares;

        public decimal Cargas_Familiares
        {
            get { return _cargas_familiares; }
            set {
                if (value !=null)
                {
                    _cargas_familiares = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Pueblo Originario no puede estar Vacío");
                    err.AgregarError("-Campo Cargas familiares no puede estar vacío");
                }
                 }
        }

        //Foraneas

        private decimal id_Nacionalidad;

        public decimal Id_Nacionalidad
        {
            get { return id_Nacionalidad; }
            set {
                if (value != 0)
                {
                    id_Nacionalidad = value;
                }
                else
                {
                   
                    err.AgregarError("-Campo Nacionalidad no puede estar Vacío");
                }

                }
        }

        private decimal id_estado_civil;

        public decimal Id_Estado_Civil
        {
            get { return id_estado_civil; }
            set {
                if (value != 0)
                {
                    id_estado_civil = value;
                }
                else
                {
                    
                    err.AgregarError("-Campo Estado Civil no puede estar Vacío");
                }
                }
        }

        private decimal id_genero;

        public decimal Id_Genero
        {
            get { return id_genero; }
            set {
                if (value != 0)
                {
                    id_genero = value;
                }
                else
                {

                    err.AgregarError("-Campo Género no puede estar Vacío");
                }
                }
        }

        private decimal id_region;

        public decimal Id_Region
        {
            get { return id_region; }
            set
            {
                    if (value != 0)
                    {
                        id_region = value;
                    }
                    else
                    {

                        err.AgregarError("-Campo Region no puede estar Vacío");
                    }
                
            }     
        }

        private decimal id_receptor;

        public decimal Id_Receptor
        {
            get { return id_receptor; }
            set {
                if (value != 0)
                {
                    id_receptor = value;
                }
                else
                {

                    err.AgregarError("-Campo Receptor no puede estar Vacío");
                }
                }
        }

        private decimal id_titulo;

        public decimal Id_Titulo
        {
            get { return id_titulo; }
            set {
                if (value != 0)
                {
                    id_titulo = value;
                }
                else
                {

                    err.AgregarError("-Campo titulo no puede estar Vacío");
                }

              }
        }


        public Postulante()
        {

        }

        //creo un objeto que me permite manipular todo en la BD
        private EntitiesSubsidio bdd = new EntitiesSubsidio();

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
                    BibliotecaControlador.POSTULANTE pos =
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
                POSTULANTE pos =
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
                Logger.Mensaje(ex.Message);
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
                            Receptor = rec.NOMBRE,
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
