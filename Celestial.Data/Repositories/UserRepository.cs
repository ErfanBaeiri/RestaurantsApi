using Celestial.Entities.User;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Celestial.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<User> GetByUserAndPassword(string userName, string password, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(password);

            return Table.Where(p => p.UserName == userName && p.PasswordHash == passwordHash).SingleOrDefaultAsync(cancellationToken);

        }
    }
}
