namespace Core.ValueObjects;

public readonly record struct ItemName
{
    private string Value { get; init; }

    public ItemName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ItemName value)
    {
        return value.Value;
    }
}