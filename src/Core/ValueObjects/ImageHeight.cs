namespace Core.ValueObjects;

public readonly record struct ImageHeight
{
    private int Value { get; init; }

    public ImageHeight(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(ImageHeight value)
    {
        return value.Value;
    }
}