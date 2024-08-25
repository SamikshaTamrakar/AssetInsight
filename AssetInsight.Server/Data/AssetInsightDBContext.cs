using AssetInsight.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetInsight.Server.Data
{
    public class AssetInsightDBContext:DbContext
    {
        public AssetInsightDBContext(DbContextOptions<AssetInsightDBContext> options) : base(options) { }

        public DbSet<Asset> Asset { get; set; }
    }
}
