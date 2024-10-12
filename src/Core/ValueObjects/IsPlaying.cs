namespace Core.ValueObjects;

public readonly record struct IsPlaying
{
    private bool Value { get; init; }

    public IsPlaying(bool value)
    {
        Value = value;
    }

    public static implicit operator string(IsPlaying value)
    {
        return value.Value.ToString();
    }

    public static implicit operator bool(IsPlaying value)
    {
        return value.Value;
    }
}