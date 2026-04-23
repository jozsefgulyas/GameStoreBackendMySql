namespace GameStore.Api.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int GameId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public int Quantity { get; set; }
    
    public bool IsOrderComplete { get; set; }
}
