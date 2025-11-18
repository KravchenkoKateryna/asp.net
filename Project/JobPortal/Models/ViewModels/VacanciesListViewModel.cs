namespace JobPortal.Models.ViewModels
{
    public class VacanciesListViewModel
    {
        public IEnumerable<Vacancy> Vacancies { get; set; } = Enumerable.Empty<Vacancy>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();

        public string? CurrentLocation { get; set; }
    }
}