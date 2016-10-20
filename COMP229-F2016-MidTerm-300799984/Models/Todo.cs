namespace COMP229_F2016_MidTerm_300799984.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Todos")]
    public partial class Todo
    {
        [Key]
        [Column(Order = 0)]
        public int TodoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TodoDescription { get; set; }

        public string TodoNotes { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Completed { get; set; }
    }
}
