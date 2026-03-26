using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class CustomerEndpoints
{
    const string GetCustomerEndpointName = "GetCustomer";

    public static RouteGroupBuilder MapCustomersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("customers")
                       .WithParameterValidation();

        // GET /customers
        group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.Customers
                     .Select(customer => customer.ToCustomerDetailsDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /customers/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Customer? customer = await dbContext.Customers.FindAsync(id);

            return customer is null ? 
                Results.NotFound() : Results.Ok(customer.ToCustomerDetailsDto());
        })
        .WithName(GetCustomerEndpointName);

        // POST /customers
        group.MapPost("/", async (CreateCustomerDto newCustomer, GameStoreContext dbContext) =>
        {
            Customer customer = newCustomer.ToEntity();

            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetCustomerEndpointName, 
                new { id = customer.Id }, 
                customer.ToCustomerDetailsDto());
        });

        // PUT /customers
        group.MapPut("/{id}", async (int id, UpdateCustomerDto updatedCustomer, GameStoreContext dbContext) =>
        {
            var existingCustomer = await dbContext.Customers.FindAsync(id);

            if (existingCustomer is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingCustomer)
                     .CurrentValues
                     .SetValues(updatedCustomer.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /customers/1
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Customers
                     .Where(customer => customer.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
