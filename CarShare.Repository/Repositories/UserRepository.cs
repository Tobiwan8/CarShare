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

        public UserModel Create(UserDTO user)
        {
            // context is our Database!!
            UserModel model = new()
            {
                UserName = user.UserName,
                Password = user.Password
            };
            _context.Users.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<UserModel> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
