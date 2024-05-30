using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetRegions();
        Region GetRegionById(Guid id);
        void CreateRegion(Region region);
        void UpdateRegion(Region region);
        void DeleteRegion(Region region);
        bool SaveChanges();
    }
}
