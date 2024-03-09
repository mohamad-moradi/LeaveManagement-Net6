namespace LeaveManagement.Common.Models
{
    public class EmployeeAllocationVM : EmployeesListVM
    {
        public List<LeaveAllocationVM> leaveAllocations { get; set; }
    }
}
