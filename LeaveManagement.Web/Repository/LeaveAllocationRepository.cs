using AutoMapper;
using LeaveManagement.Web.Constatnts;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly UserManager<Employee> userManager;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context,
            ILeaveTypeRepository leaveTypeRepository,
            UserManager<Employee> userManager,
            IMapper mapper) : base(context)
        {
            this.context = context;
            this.leaveTypeRepository = leaveTypeRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<bool> AllocationExists(string EmployeeId, int leaveTypeId, int period)
        {
            return await context.LeaveAllocations.AnyAsync(q => q.EmployeeId == EmployeeId 
                                                             && q.LeaveTypeId == leaveTypeId
                                                             && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await context.LeaveAllocations
                .Include(q => q.leaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ToListAsync();

            var employee = await userManager.FindByIdAsync(employeeId);

            var employeeAllocationmodel = mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationmodel.leaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocations);

            return employeeAllocationmodel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int AllocationId)
        {
            var allocation = await context.LeaveAllocations
                .Include(q => q.leaveType)
                .FirstOrDefaultAsync(q => q.Id == AllocationId);

            if (allocation == null)
                return null;

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);
            var model = mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = mapper.Map<EmployeesListVM>(employee);

            return model;
        }

            public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    NumberOfDayes = leaveType.DefaultDays,
                    Period = period
                });
            }

            await AddRangeAsync(allocations);
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDayes = model.NumberOfDayes;

            await UpdateAsync(leaveAllocation);
            return true;
        }
    }
}
