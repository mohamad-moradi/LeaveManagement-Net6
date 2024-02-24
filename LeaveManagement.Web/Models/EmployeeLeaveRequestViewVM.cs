using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Models
{
    public class EmployeeLeaveRequestViewVM
    {
        public EmployeeLeaveRequestViewVM(List<LeaveAllocationVM> leaveAllocations, List<LeaveRequestVM> leaveRequests)
        {
            this.leaveAllocations = leaveAllocations;
            this.leaveRequests = leaveRequests;
        }

        public List<LeaveAllocationVM> leaveAllocations {  get; set; }

        public List<LeaveRequestVM> leaveRequests { get; set; }

    }
}
