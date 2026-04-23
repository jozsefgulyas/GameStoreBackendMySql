namespace GameStore.Api.Entities;

public class Customer
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public required string Address { get; set; }
}
