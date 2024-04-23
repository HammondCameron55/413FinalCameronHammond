namespace _413FinalCameronHammond.Models
{
    public interface IFinalProjectRepository
    {
        public IQueryable<Entertainers> Entertainers { get; }

        public void AddEntertainer(Entertainers entertainer);

        public void DeleteEntertainer(Entertainers entertainer);

        public void EditEntertainer(Entertainers entertainer);

        public void SaveChanges();

        
    }
}
