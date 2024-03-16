using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Data;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LeaveManagement.Application.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Employee> userManager;
        private readonly AutoMapper.IConfigurationProvider configProvider;
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IEmailSender emailSender;

        public LeaveRequestRepository(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configProvider,
            IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository,
            IEmailSender emailSender) : base(context)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.configProvider = configProvider;
            this.mapper = mapper;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int Id)
        {
            var leaveRequest = await GetAsync(Id);
            leaveRequest.Cancelled = true;

            await UpdateAsync(leaveRequest);

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await emailSender.SendEmailAsync(user.Email, "Leave Request Cancelled", $"Your Leave Request From" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been Cancelled Successfully.");
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await context.LeaveRequests.Include(q=> q.leaveType).FirstOrDefaultAsync(q => q.Id == leaveRequestId); //await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if(approved)
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId,leaveRequest.leaveType.Id);
                int dayRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDayes -= dayRequested;

                await leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);
            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var aprovalText = approved ? "Approved" : "Declined";

            await emailSender.SendEmailAsync(user.Email, $"Leave Request {aprovalText}", $"Your Leave Request From" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been {aprovalText}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id,model.LeaveTypeId);

            if(leaveAllocation == null)
            {
                return false;
            }
            int dayRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if(dayRequested > leaveAllocation.NumberOfDayes)
            {
                return false;
            }

            var leaveRequest = mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;
            await AddAsync(leaveRequest);

            await emailSender.SendEmailAsync(user.Email, "Leave Request Submitted Successfully",$"Your Leave Request From"+
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for aproval.");

            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.LeaveRequests.Include(q => q.leaveType).ToListAsync();

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count(),
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                PendingRequests = leaveRequests.Count(q => q.Approved == null && q.Cancelled == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests) 
            {
                leaveRequest.Employee = mapper.Map<EmployeesListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string EmployeeId)
        {
            var model = await context.LeaveRequests.
                              Where(q => q.RequestingEmployeeId == EmployeeId)
                              .ProjectTo<LeaveRequestVM>(configProvider)
                              .ToListAsync();
            return model;
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? Id)
        {
           var leaveRequest = await context.LeaveRequests.Include(q => q.leaveType)
                                                         .FirstOrDefaultAsync(q => q.Id == Id);
            if(leaveRequest == null)
            {
                return null;
            }

            var model = mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = mapper.Map<EmployeesListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetailesAsync()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).leaveAllocations;
            var requests = await GetAllAsync(user.Id);
            var model = new EmployeeLeaveRequestViewVM(allocations, requests);

            return model;
        }

    }
}
