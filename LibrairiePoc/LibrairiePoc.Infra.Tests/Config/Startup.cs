namespace LibrairiePoc.Infra.Tests;

using LibrairiePoc.Infra.Ports.Gateway;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Controller;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        services.AddDbContext<DbContext, BooksContextFact>(c => c.UseInMemoryDatabase("bookContextTests"));
        services.AddTransient<BookRepositoryEF>();
        services.AddTransient<IBookStorage, BookRepositoryEF>();
        services.AddTransient<GettingBookGateway<PaginedData<Book>>>(container => new GettingBookGateway<PaginedData<Book>>(new SimplePresenter<PaginedData<Book>>(), container.GetService<IBookStorage>()));
    }
}