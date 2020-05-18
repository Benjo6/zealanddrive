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
        [Key]
        [Column ("fk_userId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fk_userId { get; set; }

        [Key]
        [Column("fk_routeId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int routeId { get; set; }

        [Required]
        [StringLength(30)]
        public string status { get; set; }

     //   public virtual Route Route { get; set; }

      //  public virtual User User { get; set; }
    }
}
