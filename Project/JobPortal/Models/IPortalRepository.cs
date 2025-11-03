namespace JobPortal.Models;

public interface IPortalRepository
{
        IQueryable<Vacancy> Vacancies { get; }
}