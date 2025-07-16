using BookCatalogAPI.Filters;
using BookCatalogAPI.Models;
using BookCatalogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<ValidationFilter>();
builder.Services.AddSingleton<LoggingFilter>();


var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RouteGroupBuilder bookGroup = app.MapGroup("/books")
    .WithTags("Books")
    .WithOpenApi();

bookGroup.MapPost("/", async ([FromBody] Book book, [FromServices] IBookService bookService, CancellationToken cancellationToken) =>
    await bookService.CreateBookAsync(book, cancellationToken))
    .AddEndpointFilter<ValidationFilter>()
    .AddEndpointFilter<LoggingFilter>()
    .WithName("CreateBook")
    .WithSummary("Create a new book")
    .WithDescription("Adds a new book to the catalog. The book must have a unique ID and valid details.");

bookGroup.MapGet("/{id:int}", async (int id, [FromServices] IBookService bookService, CancellationToken cancellationToken) =>
    await bookService.GetBookByIdAsync(id, cancellationToken))
    .AddEndpointFilter<ValidationFilter>()
    .AddEndpointFilter<LoggingFilter>()
    .WithName("GetBookById")
    .WithSummary("Get a book by its ID")
    .WithDescription("Retrieves a book from the catalog using its unique identifier.");

bookGroup.MapPut("/{id:int}", async (int id, [FromBody] Book book, [FromServices] IBookService bookService, CancellationToken cancellationToken) =>
    await bookService.UpdateBookAsync(id, book, cancellationToken))
     .AddEndpointFilter<ValidationFilter>()
    .AddEndpointFilter<LoggingFilter>()
    .WithName("UpdateBook")
    .WithSummary("Update an existing book")
    .WithDescription("Updates the details of a book in the catalog using its unique identifier.");


bookGroup.MapDelete("/{id:int}", async (int id, [FromServices] IBookService bookService, CancellationToken cancellationToken) =>

 await bookService.DeleteBookAsync(id, cancellationToken))
     .AddEndpointFilter<ValidationFilter>()
    .AddEndpointFilter<LoggingFilter>()
    .WithName("DeleteBook")
    .WithSummary("Delete a book by its ID")
    .WithDescription("Removes a book from the catalog using its unique identifier.")
    .Produces<bool>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.Run();

