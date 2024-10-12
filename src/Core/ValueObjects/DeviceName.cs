namespace Core.ValueObjects;

public readonly record struct DeviceName
{
    private string Value { get; init; }

    public DeviceName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(DeviceName value)
    {
        return value.Value;
    }
}