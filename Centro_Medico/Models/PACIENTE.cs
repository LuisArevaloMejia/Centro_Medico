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
    
    public partial class PACIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PACIENTE()
        {
            this.CITA = new HashSet<CITA>();
            this.HISTORIAL_MEDICO = new HashSet<HISTORIAL_MEDICO>();
        }
    
        public int codigoP { get; set; }
        public string nombresP { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public System.DateTime fechaNacimientoP { get; set; }
        public string sexoP { get; set; }
        public string dpiP { get; set; }
        public string direccionP { get; set; }
        public string telefonoP { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITA> CITA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_MEDICO> HISTORIAL_MEDICO { get; set; }
    }
}
