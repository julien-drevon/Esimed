// See https://aka.ms/new-console-template for more information
using ConsoleLibraiire;
using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Primary;
using LibrairiePoc.Infra.Ports.Secondary;
using LibrairiePoc.Infra.Tests;
using LibrairiePoc.UsesCase.Ports.Secondary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<DbContext, BooksContext>(c => c.UseInMemoryDatabase("bookContextTests"));
services.AddTransient<IBookRepository, BookRepositoryEF>();
services.AddTransient<BookRepositoryEF>();
services.AddTransient<GettingBookAdapter<string>>(container => new GettingBookAdapter<string>(new ConsoleBookPResenter(), container.GetService<IBookRepository>()));

var resolver = services.BuildServiceProvider();
var getAdapter = resolver.GetService<GettingBookAdapter<string>>();

Console.WriteLine(getAdapter.GetBooks(2, 1));