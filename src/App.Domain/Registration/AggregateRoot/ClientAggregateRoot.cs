using App.Domain.Abstractions.Aggregates;
using App.Domain.Abstractions.Common;
using App.Domain.Abstractions.ValueObjects;
using App.Domain.Registration.Aggregates;

namespace App.Domain.Registration.AggregateRoot;

public class ClientAggregateRoot : BaseEntity, IAggregateRoot
{
    public Client? Client { get; private set; }

    // Internal constructor to enforce aggregate creation through the factory
    internal ClientAggregateRoot(Client client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    // Method to add a new address to the patient
    public void AddAddress(Address address)
    {
        Client!.AddAddress(address);
    }

    // Method to add a new identifier to the patient
    public void AddIdentifier(Identifier identifier)
    {
        Client!.AddIdentifier(identifier);
    }

    // Method to update patient information
    public void UpdatePatientInfo(HumanName humanName, Identifier identifier)
    {
        Client!.UpdatePatientInfo(humanName, identifier);
    }

}
