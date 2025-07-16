using BookCatalogAPI.Services;
using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBookService, BookService>();



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();

