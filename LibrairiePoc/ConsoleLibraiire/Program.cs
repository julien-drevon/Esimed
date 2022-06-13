// See https://aka.ms/new-console-template for more information
using ConsoleLibraiire;
using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.Infra.Tests;
using LibrairiePoc.UsesCase.Ports.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<DbContext, BooksContext>(c => c.UseInMemoryDatabase("bookContextTests"));
services.AddTransient<IBookStorage, BookRepositoryEF>();
services.AddTransient<BookRepositoryEF>();
services.AddTransient<GettingBookApplicationController<string>>(container => new GettingBookApplicationController<string>(new ConsoleBookPResenter(), container.GetService<IBookStorage>()));

var resolver = services.BuildServiceProvider();
var getAdapter = resolver.GetService<GettingBookApplicationController<string>>();

Console.WriteLine(getAdapter.GetBooks(2, 1));