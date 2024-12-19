﻿using System.Security.Policy;
using LeaveManagementSystem.Web.Data;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }


        [Display(Name = "Email address")]
        public string Email { get; set; }
        public bool IsCompletedAllocation { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
