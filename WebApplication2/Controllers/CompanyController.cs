using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entity;
using WebApplication2.Service.EntityService;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CompanyController:ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet("")]
        public Task<IEnumerable<Company>> All()
        {
            return _companyService.All();
        }
        [HttpPost]
        public Task<Company> Create(Company company)
        {
            return _companyService.Create(company);
        }
        [HttpPut]
        public Task<Company> Update(Company company)
        {
            return _companyService.Update(company);
        }
    }
}