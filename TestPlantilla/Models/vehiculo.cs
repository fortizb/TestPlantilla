//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestPlantilla.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vehiculo()
        {
            this.hojaRuta = new HashSet<hojaRuta>();
        }
    
        public string patente { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public Nullable<int> velocidadPromedio { get; set; }
        public Nullable<int> rendimiento { get; set; }
        public Nullable<int> capacidadCarga { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hojaRuta> hojaRuta { get; set; }
    }
}
