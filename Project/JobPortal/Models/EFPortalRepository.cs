namespace JobPortal.Models
{
    public class EFPortalRepository : IPortalRepository
    {
        private PortalDbContext context;
        public EFPortalRepository(PortalDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Vacancy> Vacancies => context.Vacancies;
    }
}