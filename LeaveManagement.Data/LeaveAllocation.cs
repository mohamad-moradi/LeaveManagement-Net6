using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDayes { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType leaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public string EmployeeId { get; set; }

        public int Period {  get; set; }

    }
}
