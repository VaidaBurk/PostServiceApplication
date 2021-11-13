using AutoMapper;
using PostServiceBackend.Dtos;
using PostServiceBackend.Entities;

namespace PostServiceBackend.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<ParcelMachine, ParcelMachineDtoForRendering>();
            CreateMap<ParcelMachineAddDto, ParcelMachine>();

        }
    }
}
