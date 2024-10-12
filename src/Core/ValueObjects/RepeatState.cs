namespace Core.ValueObjects;

public readonly record struct RepeatState
{
    private string Value { get; init; }

    public RepeatState(string value)
    {
        Value = value;
    }

    public static implicit operator string(RepeatState value)
    {
        return value.Value;
    }
}