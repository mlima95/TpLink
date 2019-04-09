namespace GesperForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gesper.employe")]
    public partial class employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employe()
        {
            diplomes = new HashSet<diplome>();
        }

        [Key]
        public int emp_id { get; set; }

        [StringLength(50)]
        public string emp_nom { get; set; }

        [StringLength(50)]
        public string emp_prenom { get; set; }

        [StringLength(1)]
        public string emp_sexe { get; set; }

        [Column(TypeName = "bit")]
        public bool? emp_cadre { get; set; }

        public decimal? emp_salaire { get; set; }

        public int? emp_service { get; set; }

        public virtual service service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diplome> diplomes { get; set; }
    }
}
