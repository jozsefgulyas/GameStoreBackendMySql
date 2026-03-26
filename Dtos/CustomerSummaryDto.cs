namespace GameStore.Api.Dtos;

public record class CustomerSummaryDto(
    int Id, 
    string Name, 
    string Email,
    DateOnly DateOfBirth,
    int CopiesPurchased);
