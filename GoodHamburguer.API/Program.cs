using GoodHamburger.Application;
using GoodHamburger.Application.DTOs;
using GoodHamburger.Application.UseCases;
using GoodHamburger.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapPost("/api/orders", async (
    [FromBody] CreateOrderRequest request,
    [FromServices] CreateOrderUseCase useCase) =>
{
    var result = await useCase.Execute(request);
    return Results.Ok(result);
})
.WithName("GetOrders")
.WithTags("Orders")
.Produces<List<OrderResponse>>(StatusCodes.Status200OK);

app.MapGet("/api/orders", async (
    [FromServices] GetOrdersUseCase useCase) =>
{
    var result = await useCase.Execute();
    return Results.Ok(result);
})
.WithName("CreateOrder")
.WithTags("Orders")
.Accepts<CreateOrderRequest>("application/json")
.Produces<OrderResponse>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

app.MapGet("/api/orders/{id:guid}", async (
    Guid id,
    [FromServices] GetOrderByIdUseCase useCase) =>
{
    var order = await useCase.Execute(id);

    return order is null
        ? Results.NotFound()
        : Results.Ok(order);
})
.WithName("GetOrderById")
.WithTags("Orders")
.Produces<OrderResponse>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapDelete("/api/orders/{id:guid}", async (
    Guid id,
    [FromServices] DeleteOrderByIdUseCase useCase) =>
{
    var result = await useCase.Execute(id);

    return result == 0
        ? Results.BadRequest("Não foi possível deletar o pedido")
        : Results.Ok("Pedido deletado com sucesso");
})
.WithName("DeleteOrderById")
.WithTags("Orders")
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

app.MapGet("/api/menu", async (
    [FromServices] GetMenuUseCase useCase) =>
{
    var result = await useCase.Execute();
    return Results.Ok(result);
})
.WithName("GetMenu")
.WithTags("Menu")
.Produces(StatusCodes.Status200OK);

app.Run();