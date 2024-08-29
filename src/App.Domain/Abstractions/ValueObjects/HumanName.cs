namespace App.Domain.Abstractions.ValueObjects;

public record HumanName
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public HumanName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString() => $"{FirstName} {LastName}";
}
