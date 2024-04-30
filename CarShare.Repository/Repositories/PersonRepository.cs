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
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _context;

        public PersonRepository(DatabaseContext data)
        {
            _context = data;
        }

        public Task<PersonModel> Create(PersonDTO person)
        {
            // context is our Database!!
            PersonModel model = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                User = _context.Users.FirstOrDefault(o => o.ID == person.UserID)
            };
            _context.Persons.Add(model);
            _context.SaveChanges();
            return Task.Run(() => model);
        }

        public Task<List<PersonModel>> GetAll()
        {
            return Task.Run(() => _context.Persons.ToList());
            //return _context.Persons.Include(o => o.User).ToList();
        }

        public async Task<PersonModel?> Update(PersonUpdateDTO person)
        {
            //UserID in this case is actually PersonID when using the API
            PersonModel? dbPerson = await _context.Persons.FindAsync(person.ID); 

            if (dbPerson == null)
            {
                return dbPerson;
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;

            await _context.SaveChangesAsync();

            return dbPerson;
        }

        public async Task<PersonModel?> Delete(int personID)
        {
            PersonModel? dbPerson = await _context.Persons.FindAsync(personID);

            if (dbPerson == null)
            {
                return dbPerson;
            }

            _context.Persons.Remove(dbPerson);

            await _context.SaveChangesAsync();

            return dbPerson;
        }
    }
}
