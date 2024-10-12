namespace Core.ValueObjects;

public readonly record struct ShuffleState
{
    private bool Value { get; init; }

    public ShuffleState(bool value)
    {
        Value = value;
    }

    public static implicit operator bool(ShuffleState value)
    {
        return value.Value;
    }
}