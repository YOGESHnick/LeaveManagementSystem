using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveRequestAutoMapperProfile : Profile
    {
        public LeaveRequestAutoMapperProfile()
        {
            //CreateMap<LeaveRequest, LeaveTypeReadOnlyVM>();
            // .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<LeaveRequestCreateVM, LeaveRequest>();
            //CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
        }
    }
}
