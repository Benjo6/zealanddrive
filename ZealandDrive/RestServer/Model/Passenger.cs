namespace RestServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        public int id { get; set; }


        [Column("fk_userId")]
        public int userId { get; set; }

        [Column("fk_routeId")]
        public int routeId { get; set; }

        [Required]
        [StringLength(30)]
        public string status { get; set; }

        //public virtual Route Route { get; set; }

        //public virtual User User { get; set; }
    }
}
