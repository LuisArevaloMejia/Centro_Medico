//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Centro_Medico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORIAL_MEDICO
    {
        public int codigoHM { get; set; }
        public int codigoP { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public bool estado { get; set; }
    
        public virtual PACIENTE PACIENTE { get; set; }
    }
}
