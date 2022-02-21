namespace LibrairiePoc.Infra.Tests;

using LibrairiePoc.Infra.Ports.Secondary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        services.AddDbContext<DbContext, BooksContextFact>(c => c.UseInMemoryDatabase("bookContextTests"));
        services.AddTransient<BookRepositoryEF>();
    }
}
