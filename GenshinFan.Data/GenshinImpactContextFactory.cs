using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GenshinFan.Data
{
    public class GenshinImpactContextFactory : IDesignTimeDbContextFactory<GenshinImpactContext>
    {
        public GenshinImpactContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GenshinImpactContext>();

            var connectionString = "Server=DESKTOP-QNEBL5O\\SQLEXPRESS;Database=GenshinFan;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

            return new GenshinImpactContext(optionsBuilder.Options);
        }
    }
}




