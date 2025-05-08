using Celestial.Entities.User;

namespace Celestial.Data.Contracts
{
    public interface IUserRepository : IRepository<User>  
    {
        Task<User> GetByUserAndPassword(string userName, string password, CancellationToken cancellationToken);
    }
}
