namespace Presentation.Models;

public record AddTrackRequestDto
{
    public required string TrackUri { get; set; }
}