namespace AgentieModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proprietati")]
    public partial class Proprietati
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proprietati()
        {
            Activitatis = new HashSet<Activitati>();
            Facturis = new HashSet<Facturi>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string tip_oferta { get; set; }

        [StringLength(50)]
        public string zona { get; set; }

        public int? nr_camere { get; set; }

        public int? suprafata { get; set; }

        [StringLength(50)]
        public string amplasament { get; set; }

        [Column(TypeName = "text")]
        public string adresa { get; set; }

        public int? pret { get; set; }

        public int? comision { get; set; }

        public int id_contact { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activitati> Activitatis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facturi> Facturis { get; set; }
    }
}
