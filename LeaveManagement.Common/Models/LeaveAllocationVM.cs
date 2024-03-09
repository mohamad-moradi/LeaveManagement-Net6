using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Number Of Dayes")]
        [Required]
        [Range(1, 50, ErrorMessage = "Invalid Number Entered!")]
        public int NumberOfDayes { get; set; }

        [Required]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }
    }
}