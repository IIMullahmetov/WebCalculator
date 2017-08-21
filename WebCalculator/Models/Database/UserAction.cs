namespace WebCalculator.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAction")]
    public partial class UserAction
    {
        public int? User_Id { get; set; }

        public int? Action_Id { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime Time { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int First_Operand { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Second_Operand { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Result { get; set; }

        public virtual Action Action { get; set; }

        public virtual User User { get; set; }
    }
}
