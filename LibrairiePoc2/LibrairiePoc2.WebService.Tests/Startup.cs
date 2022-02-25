using LibrairiePoc2.UseCase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibrairiePoc2.WebService.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
        {
            services.AddDbContext<DbContext, BookContextInMemoryEF>(option => option.UseInMemoryDatabase("BookDatabase"));
            //services.AddTransient<BookCatalogueEF>(c => new BookCatalogueEF(c.GetRequiredService<DbContext>(), c.GetRequiredService<MonBookConverter>()));
            services.AddTransient<IMonconverter<BookDTO, Book>, MonBookConverter>();
        }
    }
}