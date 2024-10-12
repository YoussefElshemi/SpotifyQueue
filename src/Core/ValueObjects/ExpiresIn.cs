namespace Core.ValueObjects;

public readonly record struct ExpiresIn
{
    private int Value { get; init; }

    public ExpiresIn(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(ExpiresIn value)
    {
        return value.Value;
    }
}