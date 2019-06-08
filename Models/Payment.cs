using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Payment
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
        [Column(Order = 2)]
        public int SalesId { get; set; }

        [ForeignKey(nameof(SalesId))]
        public Sales Sales { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "decimal(10,2)")]
        public decimal PaymentAmount { get; set; }

        [Required]
        [Column(Order = 4)]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(Order = 5, TypeName = "varchar(255)")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        [Column(Order = 6)]
        public DateTime PaymentFor { get; set; }

        [Required]
        [Column(Order = 7, TypeName = "decimal(10,2)")]
        public decimal Due { get; set; }

        [Required]
        [Column(Order = 8, TypeName = "decimal(10,2)")]
        public decimal Interest { get; set; }

        [Required]
        [Column(Order = 9, TypeName = "decimal(10,2)")]
        public decimal Remaining { get; set; }

        [Required]
        [Column(Order = 10, TypeName = "varchar(20)")]
        public string Status { get; set; }

        [Required]
        [Column(Order = 11, TypeName = "decimal(10,2)")]
        public decimal Rebate { get; set; }

        [Required]
        [Column(Order = 12)]
        public int OrNo { get; set; }

        [Column(Order = 13, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 14)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 15, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 16)]
        public DateTime UpdatedDate { get; set; }
    }
}