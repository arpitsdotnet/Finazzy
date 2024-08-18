using System;
using Finazzy.Domain.Primitives;

namespace Finazzy.Domain.Entities.Users;
public sealed class Country : Entity
{
    private Country(Guid id, string countryName, string countryCode)
        : base(id)
    {
        CountryName = countryName;
        CountryCode = countryCode;
    }

    public string CountryName { get; set; }
    public string CountryCode { get; set; }
    public bool IsActive { get; private set; } = true;

    public static Country Create(string countryName, string countryCode) =>
        new Country(Guid.NewGuid(), countryName, countryCode);
}
