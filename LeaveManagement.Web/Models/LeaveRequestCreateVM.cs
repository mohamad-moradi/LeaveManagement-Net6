using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        public SelectList? LeaveTyps { get; set; }

        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date Must Be Lower Than End Date",new[] {nameof(StartDate),nameof(EndDate)});
            }
            if (RequestComments?.Length > 250)
            {
                yield return new ValidationResult("The Request Comments Is Too Large.. ", new[] { nameof(RequestComments) });
            }
        }
    }
}
