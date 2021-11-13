using Microsoft.EntityFrameworkCore;
using PostServiceBackend.Data;
using PostServiceBackend.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackend.Repositories
{
    public class ParcelMachineRepository
    {
        private readonly DataContext _context;

        public ParcelMachineRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<ParcelMachine>> GetAllAsync()
        {
            return await _context.ParcelMachines.OrderBy(m => m.Code).ToListAsync();
        }

        public async Task<ParcelMachine> GetByIdAsync(int id)
        {
            return await _context.ParcelMachines.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ParcelMachine> AddAsync(ParcelMachine parcelMachine)
        {
            _context.ParcelMachines.Add(parcelMachine);
            await _context.SaveChangesAsync();
            return parcelMachine;
        }

        public async Task UpdateAsync(ParcelMachine parcelMachine)
        {
            _context.ParcelMachines.Update(parcelMachine);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(ParcelMachine parcelMachine)
        {
            _context.ParcelMachines.Remove(parcelMachine);
            await _context.SaveChangesAsync();
        }
    }
}
