namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);
        Task<List<LeaveAllocation>> GetAllocations();
        //Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
        //Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId);
        //Task<List<EmployeeListVM>> GetEmployees();
        //Task EditAllocation(LeaveAllocationEditVM allocationEditVm);
    }
}
