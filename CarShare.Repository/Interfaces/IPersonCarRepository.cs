using CarShare.Repository.DTOs;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Interfaces
{
    public interface IPersonCarRepository
    {
        Task<PersonCarModel> Create(PersonCarDTO pcDTO);
        Task<List<PersonCarModel>> GetAll();
        Task<List<PersonCarModel>> GetAllByPersonID(int personID);
        Task<List<PersonCarModel>> GetAllByCarID(int carID);
        Task<PersonCarModel?> Delete(PersonCarDTO pcDTO);
    }
}
