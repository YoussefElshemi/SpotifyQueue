namespace Core.ValueObjects;

public readonly record struct DeviceType
{
    private string Value { get; init; }

    public DeviceType(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(DeviceType value)
    {
        return value.Value;
    }
}