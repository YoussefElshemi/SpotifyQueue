namespace Core.ValueObjects;

public readonly record struct TrackUri
{
    private string Value { get; init; }

    public TrackUri(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(TrackUri value)
    {
        return value.Value;
    }
}