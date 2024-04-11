using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _context;

        public OwnerRepository(DatabaseContext data)
        {
            _context = data;
        }

        public OwnerModel Create(OwnerModel owner)
        {
            // context is our Database!!
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public List<OwnerModel> GetAll()
        {
            return _context.Owners.ToList();
        }
    }
}
