using api.Interface;
using api.Models;

namespace api.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}