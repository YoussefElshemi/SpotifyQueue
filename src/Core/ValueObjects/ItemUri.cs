namespace Core.ValueObjects;

public readonly record struct ItemUri
{
    private string Value { get; init; }

    public ItemUri(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ItemUri value)
    {
        return value.Value;
    }
}