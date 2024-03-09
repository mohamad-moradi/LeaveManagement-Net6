namespace LeaveManagement.Common.Models
{
    public class LeaveAllocationEditVM : LeaveAllocationVM
    {
        public string EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public EmployeesListVM? Employee { get; set; }
    }
}
