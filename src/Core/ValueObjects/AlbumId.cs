namespace Core.ValueObjects;

public readonly record struct AlbumId
{
    private string Value { get; init; }

    public AlbumId(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(AlbumId value)
    {
        return value.Value;
    }
}