namespace AgentieModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cereri")]
    public partial class Cereri
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int id_contact { get; set; }

        public int? buget { get; set; }

        public int? nr_camere_min { get; set; }

        public int? nr_camere_max { get; set; }

        public int? suprafata_min { get; set; }

        public int? suprafata_max { get; set; }

        [Column(TypeName = "text")]
        public string descriere { get; set; }

        public virtual Contacte Contacte { get; set; }
    }
}
