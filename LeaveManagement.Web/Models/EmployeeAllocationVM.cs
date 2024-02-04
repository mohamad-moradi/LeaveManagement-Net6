using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Models
{
    public class EmployeeAllocationVM : EmployeesListVM
    {
        public List<LeaveAllocationVM> leaveAllocations { get; set; }
    }
}
