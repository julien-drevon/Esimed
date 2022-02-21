namespace LibrairiePoc.Infra.Tests;

using LibrairiePoc.Infra.Ports.Primary;
using LibrairiePoc.Infra.Ports.Secondary;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        services.AddDbContext<DbContext, BooksContextFact>(c => c.UseInMemoryDatabase("bookContextTests"));
        services.AddTransient<IBookRepository, BookRepositoryEF>();
        services.AddTransient<BookRepositoryEF>();
        services.AddTransient<GettingBookAdapter>(container => new GettingBookAdapter(new SimplePresenter<PaginedData<Book>>(), container.GetService<IBookRepository>()));
    }
}
