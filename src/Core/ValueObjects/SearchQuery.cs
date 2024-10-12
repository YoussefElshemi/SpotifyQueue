namespace Core.ValueObjects;

public readonly record struct SearchQuery
{
    private string Value { get; init; }

    public SearchQuery(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(SearchQuery value)
    {
        return value.Value;
    }
}