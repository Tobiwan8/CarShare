﻿using CarShare.Repository.DTOs;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<CarModel> Create(CarDTO car);
        Task<List<CarModel>> GetAll();
        Task<List<CarOwnedReturnDTO>> OwnedGet(int personID);
        Task<CarModel?> Update(CarUpdateDTO car);
        Task<CarModel?> Delete(int carID);
    }
}
