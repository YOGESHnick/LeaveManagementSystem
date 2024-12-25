namespace LeaveManagementSystem.Application.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        //public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
    }
}
