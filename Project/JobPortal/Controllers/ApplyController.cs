using Microsoft.AspNetCore.Mvc;
using JobPortal.Models;
using JobPortal.Models.ViewModels;
using JobPortal.Infrastructure;

namespace JobPortal.Controllers
{
    public class ApplyController : Controller
    {
        private readonly IPortalRepository repository;
        private const string SessionKey = "ApplicationDraft";

        public ApplyController(IPortalRepository repo)
        {
            repository = repo;
        }

        // GET: форма заявки
        public IActionResult Apply(long vacancyId)
        {
            var vacancy = repository.Vacancies
                .FirstOrDefault(v => v.VacancyID == vacancyId);

            if (vacancy == null)
                return NotFound();

            // Якщо є незавершена форма — підставляємо її
            var draft = HttpContext.Session.GetJson<Application>(SessionKey);

            var vm = new ApplicationViewModel
            {
                Vacancy = vacancy,
                Application = draft ?? new Application { VacancyID = vacancyId }
            };

            return View(vm);
        }

        // POST: отримуємо дані
        [HttpPost]
        public IActionResult Apply(ApplicationViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var e in errors)
                    Console.WriteLine(e.ErrorMessage);

                vm.Vacancy = repository.Vacancies
                    .FirstOrDefault(v => v.VacancyID == vm.Application.VacancyID);

                return View(vm);
            }

            // Якщо заявка завершена — очистити чернетку
            HttpContext.Session.Remove("ApplicationDraft");

            return RedirectToAction("Completed");
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}
