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
    
    public partial class ESPECIALIDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESPECIALIDAD()
        {
            this.MEDICO = new HashSet<MEDICO>();
        }
    
        public int codigoEsp { get; set; }
        public bool esatadoEsp { get; set; }
        public string NombreEsp { get; set; }
        public string descripccionEsp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEDICO> MEDICO { get; set; }
    }
}