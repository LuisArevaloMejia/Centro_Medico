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
    
    public partial class MEDICO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDICO()
        {
            this.CITA = new HashSet<CITA>();
        }
    
        public int codigoM { get; set; }
        public int codigoEmp { get; set; }
        public int codigoEsp { get; set; }
        public bool estadoM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITA> CITA { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual ESPECIALIDAD ESPECIALIDAD { get; set; }
    }
}
