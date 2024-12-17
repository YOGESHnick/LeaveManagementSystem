using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType : BaseEntity
    {
        [MaxLength(150)]
        //[Column(TypeName = "nvarchar(150)")]
        public required string Name { get; set; }
        public int NumberOfDays { get; set; }
    }
}
