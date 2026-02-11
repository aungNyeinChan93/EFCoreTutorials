using Database2.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Tuto_06.WebApi.Repos
{
    public static class RegionRepo
    {
        private static readonly AppDaContext _db = new AppDaContext();

        public static List<Region>? GetAllRegions()
        {
            var regions = _db.Regions.AsNoTracking().ToList<Region>();
            return regions.Count <= 0 ? null : regions;
        }

        public static bool Create(Region region)
        {
            _db.Regions.Add(region);
            int res =  _db.SaveChanges();
            return res <=0 ? false:true;
        }

        public static bool isExist(int? id)
        {
            var region = _db.Regions.Where(r=>r.RegionId == id).FirstOrDefault();
            return region is null ? false : true;
        }

        public static Region? Get(int? id)
        {
            if (!isExist(id)) return null;
            var region = _db.Regions.Where(r => r.RegionId == id).FirstOrDefault();
            return region; 
        }

        public static Region? Update(int? id,Region region)
        {
            var oldRegion = _db.Regions.Where(r => r.RegionId == id).FirstOrDefault();

            if (oldRegion == null) return null;

            oldRegion.RegionDescription = region!.RegionDescription;

            //_db.Entry(oldRegion).State = EntityState.Modified;
            int res = _db.SaveChanges();

            return res <=0 ? null : region;
        }
    }
}
