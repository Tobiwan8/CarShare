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

        public PersonModel Create(PersonDTO person)
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
            return model;
        }

        public List<PersonModel> GetAll()
        {
            return _context.Persons.ToList();
            //return _context.Persons.Include(o => o.User).ToList();
        }
    }
}
