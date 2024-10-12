namespace Core.ValueObjects;

public readonly record struct AlbumName
{
    private string Value { get; init; }

    public AlbumName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(AlbumName value)
    {
        return value.Value;
    }
}