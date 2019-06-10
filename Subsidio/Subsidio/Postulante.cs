using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int _monto_ahorro;

        public int Monto_Ahorro
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

        private char _pueblo_originario;

        public char Pueblo_Originario
        {
            get { return _pueblo_originario; }
            set { _pueblo_originario = value; }
        }

        private int _cargas_familiares;

        public int Cargas_Familiares
        {
            get { return _cargas_familiares; }
            set { _cargas_familiares = value; }
        }

        //Foraneas
        public int Id_Nacionalidad { get; set; }
        public int Id_Estado_Civil { get; set; }
        public int Id_Genero { get; set; }
        public int Id_Region { get; set; }
        public int Id_Receptor { get; set; }
        public int Id_Titulo { get; set; }



    }
}
