using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Term
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
        [Column(Order = 2, TypeName = "varchar(10)")]
        public string PayableFor { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "varchar(11)")]
        public string TermName { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "decimal(10,2)")]
        public decimal Due { get; set; }

        [Required]
        [Column(Order = 5)]
        public DateTime PaymentStart { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "decimal(10,2)")]
        public decimal Down { get; set; }

        [Required]
        [Column(Order = 7)]
        public DateTime DueDate { get; set; }

        [Required]
        [Column(Order = 8, TypeName = "decimal(10,2)")]
        public decimal Interest { get; set; }

        [Column(Order = 9, TypeName = "varchar(10)")]
        public string Status { get; set; }

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