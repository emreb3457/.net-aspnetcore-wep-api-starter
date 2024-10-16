using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser();
    }
}