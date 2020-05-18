namespace RestServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Forum")]
    public partial class Forum
    {
        public int id { get; set; }

        [Required]
        [StringLength(155)]
        public string header { get; set; }

        [Required]
        [StringLength(3000)]
        public string content { get; set; }

        public int fk_userId { get; set; }

        //public virtual User User { get; set; }
    }
}
