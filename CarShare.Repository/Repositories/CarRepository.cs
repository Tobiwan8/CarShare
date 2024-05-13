using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public async Task<CarModel?> Update(CarUpdateDTO car)
        {
            CarModel? dbCar = await _context.Cars.FindAsync(car.ID);

            if (dbCar == null)
            {
                return dbCar;
            }

            dbCar.Name= car.Name;
            dbCar.LicensePlate = car.LicensePlate;

            await _context.SaveChangesAsync();

            return dbCar;
        }
        
        public async Task<CarModel?> Delete(int carID)
        {
            CarModel? dbCar= await _context.Cars.FindAsync(carID);

            if (dbCar == null)
            {
                return dbCar;
            }

            // Find all bookings and personcars associated with the car
            var bookings = await _context.Bookings.Where(b => b.CarID == carID).ToListAsync();
            var personCars = await _context.PersonCars.Where(b => b.CarID == carID).ToListAsync();

            // Delete each booking and personcar with associated carID
            _context.Bookings.RemoveRange(bookings);
            _context.PersonCars.RemoveRange(personCars);

            // Save changes on Database before deleting the car to prevent FK constraints
            await _context.SaveChangesAsync();

            _context.Cars.Remove(dbCar);

            await _context.SaveChangesAsync();

            return dbCar;
        }

        public async Task<List<CarOwnedReturnDTO>> OwnedGet(int personID)
        {
            OwnerModel? owner = _context.Owners.FirstOrDefault(o => o.PersonID == personID);

            if(owner is not null)
            {
                List<CarOwnedReturnDTO> carsOwnedList = new();
                carsOwnedList = await _context.Cars
                    .Where(c => c.OwnerID == owner.ID)
                    .Select(c => new CarOwnedReturnDTO
                    {
                        ID = c.ID,
                        Name = c.Name,
                        LicensePlate = c.LicensePlate,
                        OwnerID = c.OwnerID
                    })
                    .ToListAsync();

                return carsOwnedList;
            }

            return [];
        }
    }
}
