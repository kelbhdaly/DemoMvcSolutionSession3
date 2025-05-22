using AutoMapper;
using Demo.BusinessLogic.DataTransferObject.Employee;
using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dist => dist.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null))
                .ForMember(dist => dist.Image , options=>options.MapFrom(src=>src.ImageName)).ReverseMap();


            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dist => dist.DepartmentId, options => options.MapFrom(src => src.DepartmentId))
                .ReverseMap();

            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)))
                              .ForMember(dist => dist.ImageName, options => options.MapFrom(src => src.Image));



        }
    }
}
