using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Entity;
using WebApplication2.Repository;

namespace WebApplication2.Service.EntityService.enforce
{
    public class CompanyService:ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public Task<IEnumerable<Company>> All()
        {
            return _companyRepository.All();
        }

        public Task<Company> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Company> CreateOrUpdate(Company entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Company> Update(Company entity)
        {
            return _companyRepository.Update(entity);
        }

        public Task<Company> Create(Company entity)
        {
            return _companyRepository.Create(entity);
        }

        public Task<List<Company>> Create(List<Company> entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Company entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string entity)
        {
            throw new System.NotImplementedException();
        }
    }
}