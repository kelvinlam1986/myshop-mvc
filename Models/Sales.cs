using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "varchar(255)")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "decimal(10,2)")]
        public decimal CashTendered { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "decimal(10,2)")]
        public decimal Discount { get; set; }

        [Required]
        [Column(Order = 5, TypeName = "decimal(10,2)")]
        public decimal AmountDue { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "decimal(10,2)")]
        public decimal CashChange { get; set; }

        [Required]
        [Column(Order = 7)]
        public DateTime DateAdded { get; set; }

        [Required]
        [Column(Order = 8, TypeName = "varchar(15)")]
        public string ModeOfPayment { get; set; }

        [Required]
        [Column(Order = 9, TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [Column(Order = 10, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 11)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 12, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 13)]
        public DateTime UpdatedDate { get; set; }

        public List<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();

    }
}