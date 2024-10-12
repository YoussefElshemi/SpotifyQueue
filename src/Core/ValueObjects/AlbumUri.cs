namespace Core.ValueObjects;

public readonly record struct AlbumUri
{
    private string Value { get; init; }

    public AlbumUri(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(AlbumUri value)
    {
        return value.Value;
    }
}