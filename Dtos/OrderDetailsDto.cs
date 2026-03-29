namespace GameStore.Api.Dtos;

public record class OrderDetailsDto(
    int Id, 
    int CustomerId,
    int GameId,
    int Quantity,
    DateTime PurchaseDate,
    bool IsOrderComplete);
