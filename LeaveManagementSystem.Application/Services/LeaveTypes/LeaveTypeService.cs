using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Services.LeaveTypes;

public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
{
    public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
    {
        // var Data =  SELECT * FROM LeaveTypes
        var data = await _context.LeavesTypes.ToListAsync();
        // convert the datamodel into a view model - use AutoMapper
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewData;
    }
    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeavesTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeavesTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }


    public bool LeaveTypeExists(int id)
    {
        return _context.LeavesTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.LeavesTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowercaseName = leaveTypeEdit.Name.ToLower();
        return await _context.LeavesTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName)
            && q.Id != leaveTypeEdit.Id);
    }

    public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
    {
        var leaveType = await _context.LeavesTypes.FindAsync(leaveTypeId);
        return leaveType.NumberOfDays < days;
    }
}
