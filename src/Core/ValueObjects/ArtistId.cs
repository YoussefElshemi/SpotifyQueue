namespace Core.ValueObjects;

public readonly record struct ArtistId
{
    private string Value { get; init; }

    public ArtistId(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ArtistId value)
    {
        return value.Value;
    }
}