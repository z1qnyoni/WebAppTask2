using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using WebApplication4.DTO;


namespace WebApplication4.Services
    

{
    public interface IHouseService
    {
        Task<List<House>> GetAllAsync();
        Task<bool> UpdateAsync(int id, HouseDTO house);
        Task<bool> DeleteAsync(int id);
        Task<House?> GetByIdAsync(int id);
        Task<House> CreateAsync(HouseDTO house);
    }
    public class HouseService : IHouseService
    {

        private readonly AppDBcontext _context;
        private readonly IMapper _mapper;

        public HouseService(AppDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<House>> GetAllAsync() => await _context.Houses.ToListAsync();

        public async Task<House?> GetByIdAsync(int id) => await _context.Houses.FindAsync(id);

        public async Task<House> CreateAsync(HouseDTO houseDTO)
        {
            var house = GetHouseFromDTO(houseDTO);
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            return house;
        }

        public async Task<bool> UpdateAsync(int id, HouseDTO house)
        {
            var existingHouse = await _context.Houses.FindAsync(id);
            if (existingHouse == null) return false;

            _context.Entry(existingHouse).CurrentValues.SetValues(house);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null) return false;

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return true;
        }
        public HouseDTO GetHouseDTO(House house)
        {
            return _mapper.Map<HouseDTO>(house);
        }
        public House GetHouseFromDTO(HouseDTO houseDTO)
        {
            return _mapper.Map<House>(houseDTO);
        }
    }
}

