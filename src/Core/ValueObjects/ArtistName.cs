namespace Core.ValueObjects;

public readonly record struct ArtistName
{
    private string Value { get; init; }

    public ArtistName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ArtistName value)
    {
        return value.Value;
    }
}