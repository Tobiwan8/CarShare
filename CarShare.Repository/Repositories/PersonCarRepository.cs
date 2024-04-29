using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
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

        public Task<PersonCarModel> Delete(PersonCarDTO pcDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonCarModel>> GetAll()
        {
            return Task.Run(() => _context.PersonCars.ToList());
        }
    }
}
