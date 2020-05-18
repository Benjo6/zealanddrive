namespace RestServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int id { get; set; }

        [Column("comment", TypeName = "text")]
        [Required]
        public string comment1 { get; set; }

        [Column("fk_userId")]
        public int userId { get; set; }

        [Column("fk_routeId")]
        public int routeId { get; set; }

       // public virtual Route Route { get; set; }

       // public virtual User User { get; set; }
    }
}
