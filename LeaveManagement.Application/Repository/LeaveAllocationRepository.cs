using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Constatnts;
using LeaveManagement.Common.Models;
using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly UserManager<Employee> userManager;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;

        public LeaveAllocationRepository(ApplicationDbContext context,
            ILeaveTypeRepository leaveTypeRepository,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider,
            IMapper mapper,
            IEmailSender emailSender) : base(context)
        {
            this.context = context;
            this.leaveTypeRepository = leaveTypeRepository;
            this.userManager = userManager;
            this.configurationProvider = configurationProvider;
            this.mapper = mapper;
            this.emailSender = emailSender;
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
                .ProjectTo<LeaveAllocationVM>(configurationProvider)
                .ToListAsync();

            var employee = await userManager.FindByIdAsync(employeeId);

            var employeeAllocationmodel = mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationmodel.leaveAllocations = allocations;

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
            var employeesHasAllocation = new List<Employee>();

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
                employeesHasAllocation.Add(employee);
            }

            foreach (var employee in employeesHasAllocation)
            {
                await emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted For {period}", $"Your {leaveType.Name} " +
                $"has been posted for the period of {period}.You have been given {leaveType.DefaultDays}.");
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

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeID)
        {
            return await context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeID);
        }
    }
}
