﻿namespace _413FinalCameronHammond.Models
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

        public void DeleteEntertainer(Entertainers entertainer)
        {
            _context.Entertainers.Remove(entertainer);
        }

        public void EditEntertainer(Entertainers entertainer)
        {
            _context.Entertainers.Update(entertainer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
