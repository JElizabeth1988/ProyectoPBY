using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaControlador;

namespace BibliotecaNegocio
{
    public class PuntajePostulante
    {
        public int ID_PUNTAJE { get; set; }
        public int CARGA_FAMILIAR { get; set; }
        public int AHORRO { get; set; }
        public int TITULO { get; set; }
        public int EDAD { get; set; }
        public int PUEBLO_ORIGINARIO { get; set; }
        public int ESTADO_CIVIL { get; set; }
        public int REGION { get; set; }
        public int TOTAL_PUNTAJE { get; set; }
        public string RUN_POSTULANTE { get; set; }

        public PuntajePostulante()
        {

        }

    }
}
