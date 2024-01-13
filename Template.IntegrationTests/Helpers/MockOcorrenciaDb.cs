using Microsoft.EntityFrameworkCore;
using Template.Persistence.Context;
using Template.Persistence.Migrations;

namespace Template.IntegrationTests.Helpers
{
    public class MockOcorrenciaDb : IDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new AppDbContext(options);
        }
    }
}
