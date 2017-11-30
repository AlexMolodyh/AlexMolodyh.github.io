namespace HW8.Model
{
    using HW8.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artist")]
    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]//Must use Date not DateTime for calendar to show up in form
        [DateValidationAtt(ErrorMessage = "Not a valid birth date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "City Of Birth")]
        public string BirthCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtWork> ArtWorks { get; set; }
    }
}
