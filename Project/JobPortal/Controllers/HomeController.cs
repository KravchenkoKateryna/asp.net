using Microsoft.AspNetCore.Mvc;
using JobPortal.Models;
using JobPortal.Models.ViewModels;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortalRepository repository;
        private const int PageSize = 4; // кількість вакансій на сторінці

        public HomeController(IPortalRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int page = 1)
        {
            var vacancies = repository.Vacancies
                .OrderBy(v => v.VacancyID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            var viewModel = new VacanciesListViewModel
            {
                Vacancies = vacancies,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Vacancies.Count()
                }
            };

            return View(viewModel);
        }
    }
}
