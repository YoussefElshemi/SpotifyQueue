namespace Core.ValueObjects;

public readonly record struct IsPrivateSession
{
    private bool Value { get; init; }

    public IsPrivateSession(bool value)
    {
        Value = value;
    }

    public static implicit operator string(IsPrivateSession value)
    {
        return value.Value.ToString();
    }

    public static implicit operator bool(IsPrivateSession value)
    {
        return value.Value;
    }
}