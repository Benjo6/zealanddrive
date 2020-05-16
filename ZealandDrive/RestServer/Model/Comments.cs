namespace RestServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string comment { get; set; }

        public int fk_userId { get; set; }

        public int fk_routeId { get; set; }

        //public virtual Route Route { get; set; }

        //public virtual Users Users { get; set; }
    }
}
