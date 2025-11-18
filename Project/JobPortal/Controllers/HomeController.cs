using Microsoft.AspNetCore.Mvc;
using JobPortal.Models;
using JobPortal.Models.ViewModels;
using System.Linq;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortalRepository repository;
        private const int PageSize = 4;

        public HomeController(IPortalRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string? location, int page = 1)
        {
            // Фільтрація за локацією
            var filteredVacancies = repository.Vacancies;

            if (!string.IsNullOrEmpty(location))
            {
                filteredVacancies = filteredVacancies
                    .Where(v => v.Location == location);
            }

            int totalItems = filteredVacancies.Count();

            var vacancies = filteredVacancies
                .OrderBy(v => v.VacancyID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var viewModel = new VacanciesListViewModel
            {
                Vacancies = vacancies,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = totalItems
                },
                CurrentLocation = location
            };

            ViewBag.SelectedLocation = location;

            return View(viewModel);
        }
    }
}
