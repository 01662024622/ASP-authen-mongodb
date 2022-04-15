using WebApplication2.Entity;
using WebApplication2.Vendors.MongoConnection;
using WebApplication2.Vendors.RepositoryGeneric.enforcement;

namespace WebApplication2.Repository.enforce
{
    public class UserRepository:RepositoryBase<User>,IUserRepository
    {
        public UserRepository(IConnectionMongoDb connection) : base(connection)
        {
        }
    }
}