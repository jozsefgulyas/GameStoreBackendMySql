using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class CustomerMapping
{
    public static Customer ToEntity(this CreateCustomerDto customer)
    {
        return new Customer()
        {
            Name = customer.Name,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth,
            Address = customer.Address
        };
    }

    public static Customer ToEntity(this UpdateCustomerDto customer, int id)
    {
        return new Customer()
        {
            Id = id,
            Name = customer.Name,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth,
            Address = customer.Address
        };
    }    

     
    public static CustomerSummaryDto ToCustomerSummaryDto(this Customer customer)
    {
        return new(
            customer.Id,
            customer.Name,
            customer.Email,
            customer.DateOfBirth,
            customer.Address
        );
    }

    public static CustomerDetailsDto ToCustomerDetailsDto(this Customer customer)
    {
        return new(
            customer.Id,
            customer.Name,
            customer.Email,
            customer.DateOfBirth,
            customer.Address
        );
    }    
}
