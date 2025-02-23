using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using WebApplication4.DTO;


namespace WebApplication4.Services
{
    public interface IresidentService
    {
    
    Task<List<Resident>> GetAllAsync();
    Task<bool> UpdateAsync(int id, ResidentDTO resident);
    Task<bool> DeleteAsync(int id);
    Task<Resident?> GetByIdAsync(int id);
    Task<Resident> CreateAsync(ResidentDTO resident);

}
    public class ResidentService : IresidentService
    {
        private readonly AppDBcontext _context;
        private readonly IMapper _mapper;

        public ResidentService(AppDBcontext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Resident>> GetAllAsync() => await _context.Residents.Include(r => r.Apartments).ToListAsync();

        public async Task<Resident?> GetByIdAsync(int id) => await _context.Residents.Include(r => r.Apartments).FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Resident> CreateAsync(ResidentDTO residentDTO)

        {
            var resident = GetResidentFromDTO(residentDTO);
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();
            return resident;
        }

        public async Task<bool> UpdateAsync(int id, ResidentDTO resident)
        {
            var existingResident = await _context.Residents.FindAsync(id);
            if (existingResident == null) return false;

            _context.Entry(existingResident).CurrentValues.SetValues(resident);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            if (resident == null) return false;

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();
            return true;
        }
        public ResidentDTO GetResidentDTO(Resident resident)
        {
            return _mapper.Map<ResidentDTO>(resident);
        }
        public Resident GetResidentFromDTO(ResidentDTO residentDTO)
        {
            return _mapper.Map<Resident>(residentDTO);
        }
    }
}
