using System.Data.Entity;

namespace WebApp.Common
{
    public class ContosoAdsContext : DbContext
    {
        public ContosoAdsContext() : base("name=ContosoAdsContext")
        {
        }

        public System.Data.Entity.DbSet<Ad> Ads { get; set; }
    
    }
}
