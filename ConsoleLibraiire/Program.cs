// See https://aka.ms/new-console-template for more information
using ConsoleLibraiire;
using LibrairiePoc.Infra.Ports.Primary;
using LibrairiePoc.Infra.Ports.Secondary;
using LibrairiePoc.Infra.Tests;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddDbContext<DbContext, BooksContextFact>(c => c.UseInMemoryDatabase("bookContextTests"));
services.AddTransient<IBookRepository, BookRepositoryEF>();
services.AddTransient<BookRepositoryEF>();
services.AddTransient<GettingBookAdapter<string>>(container => new GettingBookAdapter<string>(new ConsoleBookPResenter(), container.GetService<IBookRepository>()));

var resolver = services.BuildServiceProvider();

Console.WriteLine(resolver.GetService<GettingBookAdapter<string>>().GetBooks(2,1));
