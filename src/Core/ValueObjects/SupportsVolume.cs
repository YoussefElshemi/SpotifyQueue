namespace Core.ValueObjects;

public readonly record struct SupportsVolume
{
    private bool Value { get; init; }

    public SupportsVolume(bool value)
    {
        Value = value;
    }

    public static implicit operator string(SupportsVolume value)
    {
        return value.Value.ToString();
    }

    public static implicit operator bool(SupportsVolume value)
    {
        return value.Value;
    }
}