using CarStore.App.Models;

namespace CompanyStore.App.Services
{
    public interface ICompanyServices
    {
        List<CarStore.App.Models.Company> GetAllCompanies();
        CarStore.App.Models.Company GetCompanyById(int id);
        CarStore.App.Models.Company Modify(int id, Company newCompany);
        CarStore.App.Models.Company Create(Company createCompany);
        void Delete(int id);
    }
}
