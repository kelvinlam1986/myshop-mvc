using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(Order = 2, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 3)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 5)]
        public DateTime UpdatedDate { get; set; }
    }
}