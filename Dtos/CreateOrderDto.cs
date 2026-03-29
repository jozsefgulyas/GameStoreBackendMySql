using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateOrderDto(
    [Required] int CustomerId,
    [Required] int GameId,
    DateTime PurchaseDate,
    [Required] int Quantity,    
    bool IsOrderComplete
);