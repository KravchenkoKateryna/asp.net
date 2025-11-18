using JobPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly PortalDbContext _context;

        public NavigationMenuViewComponent(PortalDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string selectedLocation)
        {
            var locations = _context.Vacancies
                .Select(v => v.Location)
                .Distinct()
                .OrderBy(l => l)
                .ToList();

            ViewBag.SelectedLocation = selectedLocation;

            return View(locations);
        }
    }
}
