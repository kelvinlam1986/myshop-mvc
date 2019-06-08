using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class SalesDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public int SalesId { get; set; }

        [ForeignKey(nameof(SalesId))]
        public Sales Sales { get; set; }

        [Required]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [Column(Order = 3)]
        public int Quantity { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

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