using System.ComponentModel.DataAnnotations;

namespace VibbraTest.API.Dtos
{
    public struct FiscalYearFilter
    {
        [Required]
        [Range(1900, 3000)]
        public int FiscalYear { get; set; }
    }
}
