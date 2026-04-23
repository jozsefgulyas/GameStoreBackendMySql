using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class OrderMapping
{
    public static Order ToEntity(this CreateOrderDto order)
    {
        return new Order()
        {
            CustomerId = order.CustomerId,
            GameId = order.GameId,
            Quantity = order.Quantity,
            PurchaseDate = order.PurchaseDate,
            IsOrderComplete = order.IsOrderComplete
        };
    }

    public static Order ToEntity(this UpdateOrderDto order, int id)
    {
        return new Order()
        {
            Id = id,
            CustomerId = order.CustomerId,
            GameId = order.GameId,
            Quantity = order.Quantity,
            PurchaseDate = order.PurchaseDate,
            IsOrderComplete = order.IsOrderComplete
        };
    }    

    public static OrderSummaryDto ToOrderSummaryDto(this Order order)
    {
        return new(
            order.Id,
            order.CustomerId,
            order.GameId,
            order.Quantity,
            order.PurchaseDate,
            order.IsOrderComplete
        );
    }

    public static OrderDetailsDto ToOrderDetailsDto(this Order order)
    {
        return new(
            order.Id,
            order.CustomerId,
            order.GameId,
            order.Quantity,
            order.PurchaseDate,
            order.IsOrderComplete
        );
    }    
}
