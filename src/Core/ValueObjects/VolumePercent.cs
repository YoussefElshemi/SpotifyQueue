namespace Core.ValueObjects;

public readonly record struct VolumePercent
{
    private int Value { get; init; }

    public VolumePercent(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(VolumePercent value)
    {
        return value.Value;
    }
}