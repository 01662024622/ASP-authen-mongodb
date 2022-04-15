using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using WebApplication2.Config;
using WebApplication2.Entity;
using WebApplication2.Repository;
using WebApplication2.Request;
using WebApplication2.Response;

namespace WebApplication2.Service.EntityService.enforce
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        private readonly IUserRepository _userRepository;
        private readonly AppSetting _appSettings;

        public UserService(IUserRepository userRepository, IOptions<AppSetting> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("UserName", model.Username);
            User user = _userRepository.getCollectionEq().Find(filter).First();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public Task<IEnumerable<User>> All()
        {
            return _userRepository.All();
        }

        public User GetById(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = _userRepository.getCollectionEq().Find(filter).First();
            return user;
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 1 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {new Claim("_id", user._id)}),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public Task<User> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateOrUpdate(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Create(List<User> entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string entity)
        {
            throw new NotImplementedException();
        }
    }
}