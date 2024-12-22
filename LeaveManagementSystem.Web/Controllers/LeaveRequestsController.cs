using LeaveManagementSystem.Web.Models.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController(ILeaveTypeService _leaveTypesService, ILeaveRequestsService _leaveRequestsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var model = await _leaveRequestsService.GetEmployeeLeaveRequests();
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var leaveTypes = await _leaveTypesService.GetAll();
            var leaveTypesList = new SelectList(leaveTypes, "Id", "Name");
            var model = new LeaveRequestCreateVM
            {
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                LeaveTypes = leaveTypesList,
            };
            //var model = await _leaveRequestsService.GetEmployeeLeaveRequests();
            return View(model);
        }

        // Employee Create requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            //    // Validate that the days don't exceed the allocation
            //    if (await _leaveRequestsService.RequestDatesExceedAllocation(model))
            //    {
            //        ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
            //        ModelState.AddModelError(nameof(model.EndDate), "The number of days requested is invalid. ");
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        await _leaveRequestsService.CreateLeaveRequest(model);
            //        return RedirectToAction(nameof(Index));
            //    }

            //    var leaveTypes = await _leaveTypesService.GetAll();
            //    model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
            return View();
        }
        

        // Employee Cancel requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            //await _leaveRequestsService.CancelLeaveRequest(id);
            return RedirectToAction(nameof(Index));
        }

        // Admin/Supe review requests
        [Authorize(Policy = "AdminSupervisorOnly")]
        public async Task<IActionResult> ListRequests()
        {
            //var model = await _leaveRequestsService.AdminGetAllLeaveRequests();
            return View();
        }

        // Admin/Supe review requests
        public async Task<IActionResult> Review(int id)
        {
            //var model = await _leaveRequestsService.GetLeaveRequestForReview(id);
            return View();
        }

        // Admin/Supe review requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id, bool approved)
        {
            //await _leaveRequestsService.ReviewLeaveRequest(id, approved);
            return RedirectToAction(nameof(ListRequests));
        }
    }
}
