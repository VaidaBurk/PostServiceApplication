using AutoMapper;
using PostServiceBackend.Dtos;
using PostServiceBackend.Entities;
using PostServiceBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackend.Services
{
    public class ParcelMachineService
    {
        private readonly ParcelMachineRepository _parcelMachineRepository;
        private readonly IMapper _mapper;

        public ParcelMachineService(ParcelMachineRepository parcelMachineRepository, IMapper mapper)
        {
            _parcelMachineRepository = parcelMachineRepository;
            _mapper = mapper;
        }

        public async Task<List<ParcelMachineDtoForRendering>> GetAllAsync()
        {
            List<ParcelMachine> parcelMachines = await _parcelMachineRepository.GetAllAsync();
            return _mapper.Map<List<ParcelMachineDtoForRendering>>(parcelMachines);
        }

        public async Task<ParcelMachineDtoForRendering> GetByIdAsync(int id)
        {
            var parcelMachine = await _parcelMachineRepository.GetByIdAsync(id);
            if (parcelMachine == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }
            return _mapper.Map<ParcelMachineDtoForRendering>(parcelMachine);
        }

        public async Task<ParcelMachineDtoForRendering> AddAsync(ParcelMachineAddDto newParcelMachine)
        {
            var parcelMachineWithId = await _parcelMachineRepository.AddAsync(_mapper.Map<ParcelMachine>(newParcelMachine));
            return _mapper.Map<ParcelMachineDtoForRendering>(parcelMachineWithId);
        }

        public async Task<ParcelMachineDtoForRendering> UpdateAsync(int id, ParcelMachineUpdateDto updatedParcelMachine)
        {
            var parcelMachine = await _parcelMachineRepository.GetByIdAsync(id);
            if (parcelMachine == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }

            parcelMachine.Code = updatedParcelMachine.Code;
            parcelMachine.Capacity = updatedParcelMachine.Capacity;
            parcelMachine.City = updatedParcelMachine.City;

            await _parcelMachineRepository.UpdateAsync(parcelMachine);

            return _mapper.Map<ParcelMachineDtoForRendering>(parcelMachine);
        }

        public async Task RemoveAsync(int id)
        {
            var parcelMachine = await _parcelMachineRepository.GetByIdAsync(id);
            if (parcelMachine == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }

            await _parcelMachineRepository.RemoveAsync(parcelMachine);
        }
    }
}
