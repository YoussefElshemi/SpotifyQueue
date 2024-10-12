namespace Core.ValueObjects;

public readonly record struct DeviceId
{
    private string Value { get; init; }

    public DeviceId(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(DeviceId value)
    {
        return value.Value;
    }
}