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
    public class CarRepository : ICarRepository
    {
        private readonly DatabaseContext _context;

        public CarRepository(DatabaseContext data)
        {
            _context = data;
        }

        public Task<CarModel> Create(CarDTO car)
        {
            OwnerModel? owner = _context.Owners.FirstOrDefault(o => o.PersonID == car.PersonID);

            if(owner == null)
            {
                PersonModel? person = new();
                person = _context.Persons.FirstOrDefault(p => p.ID == car.PersonID);
                owner = new OwnerModel
                {
                    Person = person,
                    PersonID = person!.ID
                };
                _context.Owners.Add(owner);
                _context.SaveChanges();
            }
            
            CarModel model = new()
            {
                Name = car.Name,
                LicensePlate = car.LicensePlate,
                OwnerID = owner.ID
            };
            _context.Cars.Add(model);
            _context.SaveChanges();
            return Task.Run(() => model);
        }

        public Task<List<CarModel>> GetAll()
        {
            return Task.Run(() => _context.Cars.ToList());
        }
    }
}
