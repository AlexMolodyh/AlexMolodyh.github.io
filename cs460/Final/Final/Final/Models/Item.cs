namespace Final.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public int ItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(300)]
        public string ItemDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string SellerName { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
