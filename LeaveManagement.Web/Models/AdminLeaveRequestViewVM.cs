using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Totale Number of Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Number of Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Number of Rejected Requests")]
        public int RejectedRequests { get; set; }

        [Display(Name = "Number of Pending Requests")]
        public int PendingRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
