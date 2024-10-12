namespace Core.ValueObjects;

public readonly record struct ItemId
{
    private string Value { get; init; }

    public ItemId(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ItemId value)
    {
        return value.Value;
    }
}