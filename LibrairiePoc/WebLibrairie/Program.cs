using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Gateway;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Controller;
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
builder.Services.AddTransient<IBookStorage, BookRepositoryEF>();
builder.Services.AddTransient<BookRepositoryEF>();
builder.Services.AddTransient<GettingBookGateway<PaginedData<Book>>>(container => new GettingBookGateway<PaginedData<Book>>(new SimplePresenter<PaginedData<Book>>(), container.GetService<IBookStorage>()));

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