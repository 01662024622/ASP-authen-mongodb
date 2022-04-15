using WebApplication2.Entity;
using WebApplication2.Vendors.MongoConnection;
using WebApplication2.Vendors.RepositoryGeneric.enforcement;

namespace WebApplication2.Repository.enforce
{
    public class CompanyRepository:RepositoryBase<Company>,ICompanyRepository
    {
        public CompanyRepository(IConnectionMongoDb connection) : base(connection)
        {
        }
    }
}