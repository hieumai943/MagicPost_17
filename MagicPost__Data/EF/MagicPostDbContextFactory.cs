using MagicPost__Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Extensions
{
    // cai class nay nham muc dich de minh doc appsettings.json trong data de migration database -> giup no luu vao database
    public class MagicPostDbContextFactory : IDesignTimeDbContextFactory<MagicPostDbContext>
    {
        public MagicPostDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("MagicPostDb");
            var optionsBuilder = new DbContextOptionsBuilder<MagicPostDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MagicPostDbContext(optionsBuilder.Options);
        }
    }
}
