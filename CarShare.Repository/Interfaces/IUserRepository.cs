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
        Task<UserModel?> GetUser(string username, string password);
        Task<UserModel?> Update(UserModel user);
        Task<UserModel?> Delete(int userID);
    }
}
