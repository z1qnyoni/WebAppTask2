using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using WebApplication4.DTO;


namespace WebApplication4.Services
{
    public interface IapartmentService
    {
        Task<List<Apartment>> GetAllAsync();
        Task<bool> UpdateAsync(int id, ApartmentDTO apartment);
        Task<bool> DeleteAsync(int id);
        Task<Apartment> GetByIdAsync(int id);
        Task<Apartment> CreateAsync(ApartmentDTO apartment);

    }


    public class ApartmentService : IapartmentService
    {
        private readonly AppDBcontext _context;
        private readonly IMapper _mapper;

        public ApartmentService(AppDBcontext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Apartment>> GetAllAsync() => await _context.Apartments.Include(a => a.House).ToListAsync();

        public async Task<Apartment?> GetByIdAsync(int id) => await _context.Apartments.Include(a => a.House).FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Apartment> CreateAsync(ApartmentDTO apartmentDTO)
        {
            var apartment = GetApartmnetFromDTO(apartmentDTO);
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
            return apartment;
        }

        public async Task<bool> UpdateAsync(int id, ApartmentDTO apartment)
        {
            var existingApartment = await _context.Apartments.FindAsync(id);
            if (existingApartment == null) return false;

            _context.Entry(existingApartment).CurrentValues.SetValues(apartment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return false;

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return true;
        }
        public ApartmentDTO GetApartmnetDTO(Apartment apartment)
        {
            return _mapper.Map<ApartmentDTO>(apartment);
        }
        public Apartment GetApartmnetFromDTO(ApartmentDTO apartmentDTO)
        {
            return _mapper.Map<Apartment>(apartmentDTO);
        }
    }
}
