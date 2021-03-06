using AutoMapper;
using PostServiceBackend.Dtos;
using PostServiceBackend.Entities;

namespace PostServiceBackend.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<ParcelMachine, ParcelMachineDtoForRendering>()
                .ForMember(dest => dest.FreeSpaces, opt =>
                    opt.MapFrom((src, dest, destMember, context) => context.Items["FreeSpaces"]));

            CreateMap<ParcelMachineAddDto, ParcelMachine>();

            CreateMap<ParcelAddDto, Parcel>();

            CreateMap<Parcel, ParcelDtoForRendering>()
                .ForMember(dest => dest.ParcelMachineCode, opt =>
                    opt.MapFrom((src, dest, destMember, context) => context.Items["ParcelMachineCode"]));

        }
    }
}
