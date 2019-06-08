using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    [Table("Branch")]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "nvarchar(50)")]
        public string Contact { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "nvarchar(15)")]
        public string Skin { get; set; }

        [Column(Order = 5, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 6)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 7, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 8)]
        public DateTime UpdatedDate { get; set; }
    }
}