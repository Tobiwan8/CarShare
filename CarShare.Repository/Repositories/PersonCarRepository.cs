using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Repositories
{
    public class PersonCarRepository : IPersonCarRepository
    {
        private readonly DatabaseContext _context;

        public PersonCarRepository(DatabaseContext data)
        {
            _context = data;
        }

        public Task<PersonCarModel> Create(PersonCarDTO pcDTO)
        {
            PersonCarModel model = new()
            {
                CarID = pcDTO.CarID,
                PersonID = pcDTO.PersonID
            };
            _context.PersonCars.Add(model);
            _context.SaveChanges();
            return Task.Run(() => model);
        }

        public Task<List<PersonCarModel>> GetAll()
        {
            return Task.Run(() => _context.PersonCars.ToList());
        }

        public async Task<List<CarModel>> GetAllByPersonID(int personID)
        {
            return await _context.PersonCars.Where(b => b.PersonID == personID).Select(b => b.Car!).ToListAsync();
        }

        public async Task<List<PersonModel>> GetAllByCarID(int carID)
        {
            return await _context.PersonCars.Where(b => b.CarID == carID).Select(b => b.Person!).ToListAsync();
        }

        public async Task<PersonCarModel?> Delete(PersonCarDTO pcDTO)
        {
            PersonCarModel? personCarToDelete = await _context.PersonCars.FirstOrDefaultAsync(b => b.CarID == pcDTO.CarID && b.PersonID == pcDTO.PersonID);

            if(personCarToDelete == null) 
            {
                return personCarToDelete;
            }

            _context.PersonCars.Remove(personCarToDelete);

            await _context.SaveChangesAsync();

            return personCarToDelete;
        }
    }
}
