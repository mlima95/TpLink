namespace GesperForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gesper.service")]
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            employes = new HashSet<employe>();
        }

        [Key]
        public int ser_id { get; set; }

        [StringLength(50)]
        public string ser_designation { get; set; }

        [StringLength(1)]
        public string ser_type { get; set; }

        [StringLength(50)]
        public string ser_produit { get; set; }

        public int? ser_capacite { get; set; }

        public decimal? ser_budget { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employe> employes { get; set; }
    }
}
