using App.Domain.Abstractions.Common;
using App.Domain.Abstractions.ValueObjects;

namespace App.Domain.Registration.Aggregates;

public class Client : BaseAuditableEntity
{
    public HumanName? HumanName { get; private set; }
    public Identifier? Identifier { get; private set; }
    public List<Address>? Addresses { get; private set; }
    public List<Identifier>? Identifiers { get; private set; }


    // Protected constructor to allow EF Core to instantiate the entity
    protected Client() { }


    // Private constructor to enforce encapsulation
    private Client(HumanName humanName, Identifier identifier, List<Address> addresses, List<Identifier> identifiers)
    {
        HumanName = humanName ?? throw new ArgumentNullException(nameof(humanName));
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Addresses = addresses ?? [];
        Identifiers = identifiers ?? [];
    }


    // Static factory method to create a new Patient
    public static Client Create(HumanName humanName, Identifier identifier, List<Address>? addresses = null, List<Identifier>? identifiers = null)
    {
        return new Client(humanName, identifier, addresses!, identifiers!);
    }

    // Method to add a new address
    public void AddAddress(Address address)
    {
        ArgumentNullException.ThrowIfNull(address);
        Addresses!.Add(address);
    }

    // Method to add a new identifier
    public void AddIdentifier(Identifier identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);
        Identifiers!.Add(identifier);
    }

    // Method to update patient information
    public void UpdatePatientInfo(HumanName humanName, Identifier identifier)
    {
        ArgumentNullException.ThrowIfNull(humanName);
        ArgumentNullException.ThrowIfNull(identifier);

        HumanName = humanName;
        Identifier = identifier;
    }
}
