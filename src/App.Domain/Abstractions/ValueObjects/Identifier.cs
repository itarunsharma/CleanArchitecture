namespace App.Domain.Abstractions.ValueObjects;

public record Identifier
{
    public string Value { get; private set; }

    public Identifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Identifier value is required.", nameof(value));

        Value = value;
    }

    public override string ToString() => Value;
}
