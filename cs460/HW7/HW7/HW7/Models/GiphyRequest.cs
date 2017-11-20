namespace HW7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiphyRequest")]
    public partial class GiphyRequest
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(200)]
        public string BrowserType { get; set; }

        public DateTime RequestDate { get; set; }

        [Required]
        [StringLength(100)]
        public string SearchType { get; set; }

        [Required]
        [StringLength(20)]
        public string Rating { get; set; }

        [StringLength(100)]
        public string KeyWord { get; set; }
    }
}
