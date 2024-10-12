namespace Core.ValueObjects;

public readonly record struct ArtistUri
{
    private string Value { get; init; }

    public ArtistUri(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ArtistUri value)
    {
        return value.Value;
    }
}