//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaControlador
{
    using System;
    using System.Collections.Generic;
    
    public partial class RECEPTOR
    {
        public RECEPTOR()
        {
            this.POSTULANTE = new HashSet<POSTULANTE>();
        }
    
        public int ID_RECEPTOR { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<POSTULANTE> POSTULANTE { get; set; }
    }
}
