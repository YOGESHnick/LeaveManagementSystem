
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            // get all leave types
            var leaveTypes = await _context.LeavesTypes.ToListAsync();

            // get current period based on the year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync( q=> q.EndDate.Year == currentDate.Year);
            var monthsRemaining = period.EndDate.Month - currentDate.Month;

            // calculate leave based on number of months left in the period

            //foreach leave type, create an allocation entry
            foreach (var leaveType in leaveTypes)
            {
                // Works, but not best practice
                //var allocationExists = await AllocationExists(employeeId, period.Id, leaveType.Id);
                //if (allocationExists)
                //{
                //    continue;
                //}
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
                };

                _context.Add(leaveAllocation);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<LeaveAllocation>> GetAllocations()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .Include(q => q.Period)
                .Where(q=> q.EmployeeId == user.Id)
                .ToListAsync();

            return leaveAllocations;
        }
    }
}