namespace RestServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            //Routes = new HashSet<Route>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string color { get; set; }

        [Required]
        [StringLength(30)]
        public string brand { get; set; }

        [Required]
        [StringLength(30)]
        public string model { get; set; }

        [StringLength(30)]
        public string nummerplade { get; set; }

        public int year { get; set; }

        public int seats { get; set; }

        [Column ("fk_userId")]
        public int userId { get; set; }

        //public virtual User User { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Route> Routes { get; set; }
    }
}
