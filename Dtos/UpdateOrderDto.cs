using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateOrderDto(
    [Required] int CustomerId,
    [Required] int GameId,
    [Required] int Quantity,
    DateTime PurchaseDate,
    bool IsOrderComplete
);