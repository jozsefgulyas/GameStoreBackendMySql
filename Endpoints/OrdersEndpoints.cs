using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class OrdersEndpoints
{
    const string GetOrderEndpointName = "GetOrder";

    public static RouteGroupBuilder MapOrdersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("orders")
                       .WithParameterValidation();

        // GET /orders
        group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.Orders                   
                     .Select(order => order.ToOrderSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /orders/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Order? order = await dbContext.Orders.FindAsync(id);

            return order is null ? 
                Results.NotFound() : Results.Ok(order.ToOrderDetailsDto());
        })
        .WithName(GetOrderEndpointName);

        // POST /orders
        group.MapPost("/", async (CreateOrderDto newOrder, GameStoreContext dbContext) =>
        {
            Order order = newOrder.ToEntity();

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetOrderEndpointName, 
                new { id = order.Id }, 
                order.ToOrderDetailsDto());
        });

        // PUT /orders
        group.MapPut("/{id}", async (int id, UpdateOrderDto updatedOrder, GameStoreContext dbContext) =>
        {
            var existingOrder = await dbContext.Orders.FindAsync(id);

            if (existingOrder is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingOrder)
                     .CurrentValues
                     .SetValues(updatedOrder.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /orders/1
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Orders
                     .Where(order => order.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
