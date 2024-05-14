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
        Task<List<CarModel>> GetAllByPersonID(int personID);
        Task<List<PersonModel>> GetAllByCarID(int carID);
        Task<PersonCarModel?> Delete(PersonCarDTO pcDTO);
    }
}
