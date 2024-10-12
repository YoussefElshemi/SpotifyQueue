namespace Core.ValueObjects;

public readonly record struct RefreshToken
{
    private string Value { get; init; }

    public RefreshToken(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(RefreshToken value)
    {
        return value.Value;
    }
}