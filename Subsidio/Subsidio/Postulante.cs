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
        
        private string _run_postulante;

        public string RUN_POSTULANTE
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

        public string NOMBRE
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

        public string APELLIDO_PATERNO
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

        public string APELLIDO_MATERNO
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

        public DateTime FECHA_NACIMIENTO
        {
            get { return _fecha_Nacimiento; }
            set
            {
                if (value < DateTime.Now.AddYears(-9))
                {
                    _fecha_Nacimiento = value;
                }
                else
                {
                    //throw new ArgumentException("Campo fecha no puede estar Vacío");
                    err.AgregarError("- Postulante Menor de Edad");
                }
            }
        }

        private int _monto_ahorro;

        public int MONTO_AHORRO
        {
            get { return _monto_ahorro; }
            set
            {
                if (value >= 8000000)
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


        private int _cargas_familiares;

        public int CARGAS_FAMILIARES
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

        private int valor_vivienda;

        public int VALOR_VIVIENDA
        {
            get { return valor_vivienda; }
            set
            {
                if (value >= 25000000)
                {
                    valor_vivienda = value;
                }
                else
                {
                    //throw new ArgumentException("Campo no puede estar Vacío");
                    err.AgregarError("-El valor de la vivienda debe ser sobre $25.000.000");
                }
            }
        }

        public string ESTADO_BENEFICIO { get; set; }

        //Foraneas

        private int id_Nacionalidad;

        public int ID_NACIONALIDAD
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

        private int id_estado_civil;

        public int ID_ESTADO_CIVIL
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

        private int id_genero;

        public int ID_GENERO
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

        private int id_region;

        public int ID_REGION
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

        private int id_receptor;

        public int ID_RECEPTOR
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

        private int id_titulo;

        public int ID_TITULO
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

        private int id_vivienda;

        public int ID_VIVIENDA
        {
            get { return id_vivienda; }
            set { id_vivienda = value; }
        }

        private int id_Pueblo;

        public int ID_PUEBLO
        {
            get { return id_Pueblo; }
            set { id_Pueblo = value; }
        }

        Errores err = new Errores();
        public Errores retornar() { return err; }

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
                    bdd.POSTULANTE.Find(RUN_POSTULANTE);

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
                bdd.POSTULANTE.First(po => po.RUN_POSTULANTE.Equals(RUN_POSTULANTE));
               
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
                POSTULANTE pos = bdd.POSTULANTE.Find(RUN_POSTULANTE);
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
                            RUN_POSTULANTE = pos.RUN_POSTULANTE,
                            NOMBRE = pos.NOMBRE,
                            APELLIDO_PATERNO = pos.APELLIDO_PATERNO,
                            APELLIDO_MATERNO = pos.APELLIDO_MATERNO,
                            FECHA_NACIMIENTO = pos.FECHA_NACIMIENTO,
                            MONTO_AHORRO = pos.MONTO_AHORRO,
                            CARGAS_FAMILIARES = pos.CARGAS_FAMILIARES,
                            VALOR_VIVIENDA = pos.VALOR_VIVIENDA,
                            ESTADO_BENEFICIO=pos.ESTADO_BENEFICIO,
                            ID_NACIONALIDAD=pos.ID_NACIONALIDAD,
                            ID_ESTADO_CIVIL=pos.ID_ESTADO_CIVIL,
                            ID_GENERO=pos.ID_GENERO,
                            ID_REGION=pos.ID_REGION,
                            ID_RECEPTOR=pos.ID_RECEPTOR,
                            ID_TITULO=pos.ID_TITULO,
                            ID_VIVIENDA= pos.ID_VIVIENDA,
                            ID_PUEBLO=pos.ID_PUEBLO

              
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
                        join viv in bdd.VIVIENDA
                         on pos.ID_VIVIENDA equals viv.ID_VIVIENDA
                        join pue in bdd.PUEBLO_ORIGINARIO
                         on pos.ID_PUEBLO equals pue.ID_PUEBLO
                        select new listaPostulantes()
                        {
                            Rut = pos.RUN_POSTULANTE,
                            Nombre = pos.NOMBRE,
                            Apellido_Paterno = pos.APELLIDO_PATERNO,
                            Apellido_Materno = pos.APELLIDO_MATERNO,
                            Fecha_Nacimiento = pos.FECHA_NACIMIENTO,
                            Monto_Ahorro = pos.MONTO_AHORRO,
                            valor_vivienda = pos.VALOR_VIVIENDA,
                            Cargas_Familiares = pos.CARGAS_FAMILIARES,
                            estado_beneficio=pos.ESTADO_BENEFICIO,
                            Nacionalidad = nac.ID_NACIONALIDAD,
                            Estado_Civil = ecivil.DESCRIPCION,
                            Genero = sexo.DESCRIPCION,
                            Region = reg.NOMBRE,
                            Receptor = rec.NOMBRE,
                            Titulo = tit.DESCRIPCION,
                            Vivienda= viv.DESCRIPCION,
                            Pueblo=pue.NOMBRE
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
        public int Monto_Ahorro { get; set; }
        public int valor_vivienda { get; set; }
        public int Cargas_Familiares { get; set; }
        public string estado_beneficio { get; set; }
        public int Nacionalidad { get; set; }
        public string Estado_Civil { get; set; }
        public string Genero { get; set; }
        public string Region { get; set; }
        public string Receptor { get; set; }
        public string Titulo { get; set; }
        public string Vivienda { get; set; }
        public string Pueblo { get; set; }

        public listaPostulantes()
        {

        }

    }

    
}
