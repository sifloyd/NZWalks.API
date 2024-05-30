using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SqlRegionRepository:IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateRegion(Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            dbContext.Add(region);
            dbContext.SaveChanges();
        }

        public void DeleteRegion(Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            dbContext.Regions.Remove(region);
            dbContext.SaveChanges();
        }

        public Region GetRegionById(Guid id)
        {
            return dbContext.Regions.Find(id);
        }

        public IEnumerable<Region> GetRegions()
        {
            return dbContext.Regions.ToList();
        }

        public bool SaveChanges()
        {
            return (dbContext.SaveChanges() >= 0);
        }

        public void UpdateRegion(Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            dbContext.Regions.Update(region);
            dbContext.SaveChanges();
        }
    }
}
