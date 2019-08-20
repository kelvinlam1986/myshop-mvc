using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(30)")]
        public string LastName { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "varchar(30)")]
        public string Contact { get; set; }

        [Column(Order = 5, TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }

        [Column(Order = 6, TypeName = "varchar(300)")]
        public string Picture { get; set; }

        [Column(Order = 7)]
        public DateTime BirthDate { get; set; }

        [Column(Order = 8, TypeName = "nvarchar(30)")]
        public string NickName { get; set; }

        [Column(Order = 9, TypeName = "varchar(30)")]
        public string HouseStatus { get; set; }

        [Column(Order = 10, TypeName = "varchar(20)")]
        public string Years { get; set; }

        [Column(Order = 11, TypeName = "nvarchar(1000)")]
        public string Rent { get; set; }

        [Column(Order = 12, TypeName = "nvarchar(100)")]
        public string EmployerName { get; set; }

        [Column(Order = 13, TypeName = "nvarchar(30)")]
        public string EmployerNo { get; set; }

        [Column(Order = 14, TypeName = "nvarchar(100)")]
        public string EmployerAddress { get; set; }

        [Column(Order = 15, TypeName = "varchar(10)")]
        public string EmployerYear { get; set; }

        [Column(Order = 16, TypeName = "nvarchar(30)")]
        public string Occupation { get; set; }

        [Column(Order = 17, TypeName = "nvarchar(30)")]
        public string Salary { get; set; }

        [Column(Order = 18, TypeName = "nvarchar(30)")]
        public string Spouse { get; set; }

        [Column(Order = 19, TypeName = "nvarchar(50)")]
        public string SpouseEmp { get; set; }

        [Column(Order = 20, TypeName = "varchar(30)")]
        public string SpouseNo { get; set; }

        [Column(Order = 21, TypeName = "nvarchar(100)")]
        public string SpouseDetails { get; set; }

        [Column(Order = 22, TypeName = "varchar(30)")]
        public string SpouseIncome { get; set; }

        [Column(Order = 23, TypeName = "nvarchar(30)")]
        public string CoMaker { get; set; }

        [Column(Order = 24, TypeName = "nvarchar(100)")]
        public string CoMakerDetails { get; set; }

        [Column(Order = 25, TypeName = "varchar(10)")]
        public string CreditStatus { get; set; }

        [Column(Order = 26, TypeName = "nvarchar(1000)")]
        public string CiRemarks { get; set; }

        [Column(Order = 27, TypeName = "nvarchar(50)")]
        public string CiName { get; set; }
        [Column(Order = 28)]
        public DateTime CiDate { get; set; }
        [Column(Order = 29)]
        public bool PaySlip { get; set; }
        [Column(Order = 30)]
        public bool ValidId { get; set; }
        [Column(Order = 31)]
        public bool Cert { get; set; }
        [Column(Order = 32)]
        public bool Cedula { get; set; }
        [Column(Order = 33)]
        public bool Income { get; set; }

        [Column(Order = 34, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 35)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 36, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 37)]
        public DateTime UpdatedDate { get; set; }

        [Column(Order = 38)]
        [Required]
        public int BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        [Column(Order = 39)]
        public Branch Branch { get; set; }
    }
}