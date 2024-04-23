namespace _413FinalCameronHammond.Models
{
    public interface IFinalProjectRepository
    {
        public IQueryable<Entertainers> Entertainers { get; }

        public void AddEntertainer(Entertainers entertainer);

        public void SaveChanges();
    }
}
