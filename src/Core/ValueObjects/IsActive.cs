namespace Core.ValueObjects;

public readonly record struct IsActive
{
    private bool Value { get; init; }

    public IsActive(bool value)
    {
        Value = value;
    }

    public static implicit operator string(IsActive value)
    {
        return value.Value.ToString();
    }

    public static implicit operator bool(IsActive value)
    {
        return value.Value;
    }
}