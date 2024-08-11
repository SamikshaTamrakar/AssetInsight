using AssetInsight.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetInsight.Server.Data
{
    public class AssetInsightDBContext:DbContext
    {
        public AssetInsightDBContext(DbContextOptions<AssetInsightDBContext> options) : base(options) { }

        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<Investor> Investors { get; set; }
    }
}
