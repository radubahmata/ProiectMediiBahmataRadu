namespace AgentieModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activitati")]
    public partial class Activitati
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int id_contact { get; set; }

        public DateTime data { get; set; }

        public int? id_proprietate { get; set; }

        public string descriere { get; set; }

        public virtual Contacte Contacte { get; set; }

        public virtual Proprietati Proprietati { get; set; }
    }
}
