namespace Final.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BuyerName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime TimeStamp { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
