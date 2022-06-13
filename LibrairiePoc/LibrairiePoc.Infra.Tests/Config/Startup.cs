namespace LibrairiePoc.Infra.Tests;

using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Gateway;
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
        services.AddTransient<IBookGateway, BookRepositoryEF>();
        services.AddTransient<GettingBookApplicationController<PaginedData<Book>>>(container => new GettingBookApplicationController<PaginedData<Book>>(new SimplePresenter<PaginedData<Book>>(), container.GetService<IBookGateway>()));
    }
}