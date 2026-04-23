namespace GameStore.Api.Dtos;

public record class CustomerDetailsDto(
    int Id, 
    string Name, 
    string Email,
    DateOnly DateOfBirth,
    string Address);
