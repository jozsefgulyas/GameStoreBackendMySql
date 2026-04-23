using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateCustomerDto(
    [Required][StringLength(50)] string Name,
    [Required][EmailAddress] string Email,
    DateOnly DateOfBirth,
    [Required][StringLength(100)] string Address
);