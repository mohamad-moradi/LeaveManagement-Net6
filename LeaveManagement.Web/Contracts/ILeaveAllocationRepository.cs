﻿using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string EmployeeId, int leaveTypeId, int period);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId,int leaveTypeID);
        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int AllocationId);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
