namespace GameStore.Api.Dtos;

public record class OrderSummaryDto(
    int Id, 
    int CustomerId,
    int GameId,
    int Quantity,
    DateTime PurchaseDate,
    bool IsOrderComplete);
