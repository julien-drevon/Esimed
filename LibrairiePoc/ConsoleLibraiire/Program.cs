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

//public interface ILanceDeProvider
//{
//    (int De1, int De2, int De3) LancerDe();
//}


//public class LanceDeFact : ILanceDeProvider
//{
//    (int De1, int De2, int De3) _Val;
//    public LanceDeFact(int val1, int val2, int val3)
//    {
//        this._Val = new(val1, val2, val3);
//    }

//    public (int De1, int De2, int De3) LancerDe()
//    {
//        return this._Val;
//    }
//}

//public class LanceDe421 : ILanceDeProvider
//{
//    public (int De1, int De2, int De3) LancerDe()
//    {
//        return new(4, 2, 1);
//    }
//}

