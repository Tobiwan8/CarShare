using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;

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

        public Task<UserModel> Update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
