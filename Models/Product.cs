using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(Order = 2, TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Column(Order = 3, TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(300)")]
        public string Picture { get; set; }

        [Required]
        [Column(Order = 5)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Column(Order = 6)]
        public int Quantity { get; set; }

        [Column(Order = 7)]
        public int Reorder { get; set; }

        [Required]
        [Column(Order = 8)]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        [Required]
        [Column(Order = 9, TypeName = "varchar(50)")]
        public string Serial { get; set; }

        [Column(Order = 10, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 11)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 12, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 13)]
        public DateTime UpdatedDate { get; set; }
    }
}