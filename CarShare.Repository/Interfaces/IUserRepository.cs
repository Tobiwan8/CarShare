using CarShare.Repository.DTOs;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> Create(UserDTO user);
        Task<List<UserModel>> GetAll();
        Task<UserModel> Update(UserDTO user);
    }
}
