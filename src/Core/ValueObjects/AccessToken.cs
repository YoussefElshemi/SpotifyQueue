namespace Core.ValueObjects;

public readonly record struct AccessToken
{
    private string Value { get; init; }

    public AccessToken(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(AccessToken value)
    {
        return value.Value;
    }
}