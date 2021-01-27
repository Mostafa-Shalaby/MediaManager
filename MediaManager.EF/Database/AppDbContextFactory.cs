using MediaManager.Domains.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace MediaManager.EF.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            if (!Directory.Exists(AppFilePath.ProgramAppData))
            {
                Directory.CreateDirectory(AppFilePath.ProgramAppData);
            }
            builder.UseSqlite("Data Source=" + AppFilePath.LocalDbFile);
            return new AppDbContext(builder.Options);
        }
    }
}
