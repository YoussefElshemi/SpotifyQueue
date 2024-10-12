namespace Core.ValueObjects;

public readonly record struct ProgressMs
{
    private int Value { get; init; }

    public ProgressMs(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(ProgressMs value)
    {
        return value.Value;
    }
}