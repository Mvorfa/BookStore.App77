using CarStore.App.Data;
using CarStore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyStore.App.Services
{
    public class CompaniesServices : ICompanyServices
    {
        //deklarimi i appdbcontext
        private AppDbContext _context;
        public CompaniesServices(AppDbContext context)
        {
            _context = context;
        }


        public string GetAll()
        {
            throw new NotImplementedException();
        }

   /// <summary>
   /// //////
        

        public void Delete(int id)
        {
            var result = _context.Companies.FirstOrDefault(n => n.Id == id);
            _context.Companies.Remove(result);
            _context.SaveChanges();
        }

       
        public Company GetCompanyById(int id)
        {
            var newCompany = _context.Companies
                .FirstOrDefault(n => n.Id == id);

            return newCompany;
        }

        public Company Modify(int id, Company newCompany)
        {
            var result = _context.Companies.FirstOrDefault(n => n.Id == id);
            result.CompanyName = newCompany.CompanyName;
            //result.Author = newBook.Author;
            //result.NrOfPages = newBook.NrOfPages;
            //result.PublishedYear = newBook.PublishedYear;
            //result.URLimg = newBook.URLimg; 

            _context.Companies.Update(result);
            _context.SaveChanges();
            return newCompany;
        }

        public Company Create(Company createCompany)
        {
            _context.Companies.Add(createCompany);
            _context.SaveChanges();
            return createCompany;
        }

        public List<Company> GetAllCompanies()
        {
            var allCompanies = _context.Companies.Include(n => n.Cars).ToList();
            return allCompanies;
        }
    }

}