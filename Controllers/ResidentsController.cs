using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using WebApplication4.DTO;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly IresidentService _residentService;

        public ResidentsController(IresidentService residentService)
        {
            _residentService = residentService;
        }

        // GET: api/Residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
            return await _residentService.GetAllAsync();
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
            return await _residentService.GetByIdAsync(id);
        }

        // PUT: api/Residents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<bool> PutResident(int id, ResidentDTO resident)
        {
            return await _residentService.UpdateAsync(id, resident);
        }

        // POST: api/Residents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResident(ResidentDTO resident)
        {
            return await _residentService.CreateAsync(resident);
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteResident(int id)
        {
            return await _residentService.DeleteAsync(id);
        }
    }
}
