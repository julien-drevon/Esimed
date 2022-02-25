using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Primary;
using LibrairiePoc.Infra.Ports.Secondary;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.EntityFrameworkCore;
using WebLibrairie;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext, BooksContext>(c => c.UseInMemoryDatabase("bookContextTests"));
builder.Services.AddTransient<IBookRepository, BookRepositoryEF>();
builder.Services.AddTransient<BookRepositoryEF>();
builder.Services.AddTransient<GettingBookAdapter<PaginedData<Book>>>(container => new GettingBookAdapter<PaginedData<Book>>(new SimplePresenter<PaginedData<Book>>(), container.GetService<IBookRepository>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();