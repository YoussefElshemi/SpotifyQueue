namespace Core.ValueObjects;

public readonly record struct ImageWidth
{
    private int Value { get; init; }

    public ImageWidth(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(ImageWidth value)
    {
        return value.Value;
    }
}