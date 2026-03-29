using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateCustomerDto(
    [Required][StringLength(50)] string Name,
    [Required][EmailAddress] string Email,
    DateOnly DateOfBirth,
    string Address
);