using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Interfaces
{
    public interface IOwnerRepository
    {
        Task<OwnerModel> Create(int ownerID);
        Task<List<OwnerModel>> GetAll();
    }
}
