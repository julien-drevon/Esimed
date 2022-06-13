﻿// See https://aka.ms/new-console-template for more information
using ConsoleLibraiire;
using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Gateway;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.Infra.Tests;
using LibrairiePoc.UsesCase.Ports.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<DbContext, BooksContext>(c => c.UseInMemoryDatabase("bookContextTests"));
services.AddTransient<IBookStorage, BookRepositoryEF>();
services.AddTransient<BookRepositoryEF>();
services.AddTransient<GettingBookGateway<string>>(container => new GettingBookGateway<string>(new ConsoleBookPResenter(), container.GetService<IBookStorage>()));

var resolver = services.BuildServiceProvider();
var getAdapter = resolver.GetService<GettingBookGateway<string>>();

Console.WriteLine(getAdapter.GetBooks(2, 1));