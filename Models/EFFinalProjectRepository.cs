namespace _413FinalCameronHammond.Models
{
    public class EFFinalProjectRepository : IFinalProjectRepository 
    {
        private FinalProjectContext _context;

        public EFFinalProjectRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public IQueryable<Entertainers> Entertainers => _context.Entertainers;

        public void AddEntertainer(Entertainers entertainer)
        {
            _context.Entertainers.Add(entertainer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
