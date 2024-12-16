using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        //public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
    }
}
