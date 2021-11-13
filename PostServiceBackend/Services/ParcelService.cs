using AutoMapper;
using PostServiceBackend.Dtos;
using PostServiceBackend.Entities;
using PostServiceBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackend.Services
{
    public class ParcelService
    {
        private readonly ParcelRepository _parcelRepository;
        private readonly ParcelMachineRepository _parcelMachineRepository;
        private readonly ParcelMachineService _parcelMachineService;
        private readonly IMapper _mapper;

        public ParcelService(ParcelRepository parcelRepository, ParcelMachineRepository parcelMachineRepository, ParcelMachineService parcelMachineService, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _parcelMachineRepository = parcelMachineRepository;
            _parcelMachineService = parcelMachineService;
            _mapper = mapper;
        }

        public async Task<List<ParcelDtoForRendering>> GetAllAsync()
        {
            List<Parcel> parcels = await _parcelRepository.GetAllAsync();
            List<ParcelMachine> parcelMachines = await _parcelMachineRepository.GetAllAsync();
            List<ParcelDtoForRendering> mappedParcels = new();

            foreach (Parcel parcel in parcels)
            {
                ParcelDtoForRendering mappedParcel = new()
                {
                    Id = parcel.Id,
                    Weight = parcel.Weight,
                    Receiver = parcel.Receiver,
                    Phone = parcel.Phone,
                    Info = parcel.Info,
                    ParcelMachineId = parcel.ParcelMachineId != null ? parcel.ParcelMachineId : null,
                    ParcelMachineCode = parcel.ParcelMachineId != null ?
                        parcelMachines.FirstOrDefault(m => m.Id == parcel.ParcelMachineId).Code.ToString() : "Update needed!"
                };
                mappedParcels.Add(mappedParcel);
            }
            return mappedParcels;
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            Parcel parcel = await _parcelRepository.GetByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }
            return parcel;
        }

        public async Task<ParcelDtoForRendering> AddAsync(ParcelAddDto newParcel)
        {
            ParcelMachine parcelMachine = await _parcelMachineRepository.GetByIdAsync((int)newParcel.ParcelMachineId);
            if (parcelMachine == null)
            {
                throw new ArgumentException($"Parcel machine id {newParcel.ParcelMachineId} does not exist.");
            }

            var freeSpacesInMachine = await _parcelMachineService.GetFreeSpacesInMachine(parcelMachine.Id);
            if (freeSpacesInMachine < 1)
            {
                throw new ArgumentException($"Parcel machine {parcelMachine.Code} is full. Please select another machine.");
            }

            Parcel parcelWithId = await _parcelRepository.AddAsync(_mapper.Map<Parcel>(newParcel));

            return _mapper.Map<ParcelDtoForRendering>(parcelWithId, opt => opt.Items["ParcelMachineCode"] = parcelMachine.Code);
        }

        public async Task<ParcelDtoForRendering> UpdateAsync(int id, ParcelUpdateDto updatedParcel)
        {
            Parcel parcel = await _parcelRepository.GetByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }

            ParcelMachine parcelMachine = await _parcelMachineRepository.GetByIdAsync((int)updatedParcel.ParcelMachineId);
            if (parcelMachine == null)
            {
                throw new ArgumentException($"Parcel machine id {updatedParcel.ParcelMachineId} does not exist.");
            }

            var freeSpacesInMachine = await _parcelMachineService.GetFreeSpacesInMachine(parcelMachine.Id);
            if (freeSpacesInMachine < 1)
            {
                throw new ArgumentException($"Parcel machine {parcelMachine.Code} is full. Please select another machine.");
            }

            parcel.Weight = updatedParcel.Weight;
            parcel.Receiver = updatedParcel.Receiver;
            parcel.Phone = updatedParcel.Phone;
            parcel.Info = updatedParcel.Info;
            parcel.ParcelMachineId = updatedParcel.ParcelMachineId;

            await _parcelRepository.UpdateAsync(parcel);

            return _mapper.Map<ParcelDtoForRendering>(parcel, opt => opt.Items["ParcelMachineCode"] = parcelMachine.Code);
        }

        public async Task RemoveAsync(int id)
        {
            Parcel parcel = await _parcelRepository.GetByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }

            await _parcelRepository.RemoveAsync(parcel);
        }

        public async Task<List<ParcelDtoForRendering>> GetFilteredByParcelMachineId(int parcelMachineId)
        {
            if (parcelMachineId != 0)
            {
                List<Parcel> filteredParcels = await _parcelRepository.GetFilteredByParcelMachineId(parcelMachineId);
                ParcelMachine parcelMachine = await _parcelMachineRepository.GetByIdAsync(parcelMachineId);

                return _mapper.Map<List<ParcelDtoForRendering>>(filteredParcels, opt => opt.Items["ParcelMachineCode"] = parcelMachine.Code);
            }
            return await GetAllAsync();
        }
    }
}
