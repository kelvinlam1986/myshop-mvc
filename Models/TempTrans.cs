using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class TempTrans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(Order = 3)]
        public int Quantity { get; set; }

        [Required]
        [Column(Order = 4)]
        public int CustomerId { get; set; }
    }
}