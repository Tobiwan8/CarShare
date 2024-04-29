using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext data)
        {
            _context = data;
        }

        public Task<UserModel>Create(UserDTO user)
        {
            // context is our Database!!
            UserModel model = new()
            {
                UserName = user.UserName,
                Password = user.Password
            };
            _context.Users.Add(model);
            _context.SaveChanges();
            return Task.Run(() => model);
        }

        public Task<List<UserModel>> GetAll()
        {
            return Task.Run(() => _context.Users.ToList());
        }

        public async Task<UserModel?> Update(UserModel user)
        {
            UserModel? dbUser = await _context.Users.FindAsync(user.ID);

            if(dbUser == null)
            {
                return dbUser;
            }

            dbUser.UserName = user.UserName;
            dbUser.Password = user.Password;
            dbUser.Role = user.Role;

            await _context.SaveChangesAsync();

            return dbUser;
        }

        public async Task<UserModel?> Delete(int userID)
        {
            UserModel? dbUser = await _context.Users.FindAsync(userID);

            if (dbUser == null)
            {
                return dbUser;
            }
            
            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();

            return dbUser;
        }
    }
}
