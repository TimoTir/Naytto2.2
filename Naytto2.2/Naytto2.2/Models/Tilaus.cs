//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Naytto2._2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tilaus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tilaus()
        {
            this.Tilausrivi = new HashSet<Tilausrivi>();
        }
    
        public int tilausId { get; set; }
        public int asiakasId { get; set; }
        public System.DateTime TilausPvm { get; set; }
    
        public virtual Asiakkaat Asiakkaat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tilausrivi> Tilausrivi { get; set; }
    }
}
