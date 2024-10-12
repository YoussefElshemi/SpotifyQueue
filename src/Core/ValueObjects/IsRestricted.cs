namespace Core.ValueObjects;

public readonly record struct IsRestricted
{
    private bool Value { get; init; }

    public IsRestricted(bool value)
    {
        Value = value;
    }

    public static implicit operator bool(IsRestricted value)
    {
        return value.Value;
    }
}