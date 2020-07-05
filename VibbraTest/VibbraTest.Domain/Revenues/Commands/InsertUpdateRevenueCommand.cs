using System;
using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Revenues.Commands
{
    public class InsertUpdateRevenueCommand
    {
        [Required]
        [Range(1, 9999999)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(Revenue.InvoiceIdMaxLenght)]
        public string InvoiceId { get; set; }

        [Required]
        [StringLength(Revenue.DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public DateTime AccrualDate { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
