using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record Address
    {
        public string Region { get; }
    public string City { get; }
    public string Street { get; }
    public string Building { get; }
    public string Apartment { get; }

    private Address(string region, string city, string street, string building, string apartment)
    {
        Region = region;
        City = city;
        Street = street;
        Building = building;
        Apartment = apartment;
    }

        public static Result<Address> Create(string region, string city, string street, string building, string apartment)
        {
            var regionResult = Validate(region, "Region");
            var cityResult = Validate(city, "City");
            var streetResult = Validate(street, "Street");
            var buildingResult = Validate(building, "Building");
            var apartmentResult = Validate(apartment, "Apartment");

            return Result.Combine(regionResult, cityResult, streetResult, buildingResult, apartmentResult)
                .Map(() => new Address(region, city, street, building, apartment));
        }

        private static Result Validate(string value, string fieldName) =>
            string.IsNullOrWhiteSpace(value)
                ? Result.Failure($"{fieldName} cannot be empty.")
                : Result.Success();
    }
}
