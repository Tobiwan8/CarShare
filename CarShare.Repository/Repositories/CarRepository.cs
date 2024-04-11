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
    public class CarRepository : ICarRepository
    {
        private readonly DatabaseContext _context;

        public CarRepository(DatabaseContext data)
        {
            _context = data;
        }

        public CarModel Create(CarDTO car)
        {
            // context is our Database!!
            CarModel model = new()
            {
                Name = car.Name,
                LicensePlate = car.LicensePlate,
                Owner = _context.Owners.FirstOrDefault(o => o.ID == car.OwnerID)
            };
            _context.Cars.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<CarModel> GetAll()
        {
            return _context.Cars.ToList();
        }
    }
}
