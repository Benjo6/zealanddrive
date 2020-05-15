namespace RestServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Route")]
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            Comments = new HashSet<Comments>();
            Passenger = new HashSet<Passenger>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string routestart { get; set; }

        [Required]
        [StringLength(30)]
        public string routeend { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public DateTime starttime { get; set; }

        public int fk_carId { get; set; }

        public virtual Car Car { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger> Passenger { get; set; }
    }
}