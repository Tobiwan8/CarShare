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

        public Task<OwnerModel> Create(int ownerID)
        {
            OwnerModel owner = new() { PersonID = ownerID};
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return Task.Run(() => owner);
        }

        public Task<List<OwnerModel>> GetAll()
        {
            return Task.Run(() => _context.Owners.ToList());
        }
    }
}
