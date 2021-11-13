using Microsoft.EntityFrameworkCore;
using PostServiceBackend.Data;
using PostServiceBackend.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackend.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _context;

        public ParcelRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _context.Parcels.OrderByDescending(p => p.Weight).ToListAsync();
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            return await _context.Parcels.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Parcel> AddAsync(Parcel parcel)
        {
            _context.Parcels.Add(parcel);
            await _context.SaveChangesAsync();
            return parcel;
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _context.Parcels.Update(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Parcel parcel)
        {
            _context.Parcels.Remove(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Parcel>> GetFilteredByParcelMachineId(int id)
        {
            return await _context.Parcels.Where(p => p.ParcelMachineId == id).ToListAsync();
        }
    }
}
