using App.Domain.Abstractions.ValueObjects;
using App.Domain.Registration.AggregateRoot;

namespace App.Domain.Registration.Factories;

public interface IClientFactory
{
    ClientAggregateRoot CreatePatient(HumanName humanName, Identifier identifier, List<Address>? addresses = null, List<Identifier>? identifiers = null);
}
