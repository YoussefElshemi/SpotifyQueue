namespace Presentation.Models;

public record SeekRequestDto
{
    public required int ProgressMs { get; set; }
}