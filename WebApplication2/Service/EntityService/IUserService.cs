using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Entity;
using WebApplication2.Request;
using WebApplication2.Response;
using WebApplication2.Vendors.Service;

namespace WebApplication2.Service.EntityService
{
    public interface IUserService:IServiceBase<User>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(string id);
    }
    
}