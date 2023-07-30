using System.Text.Json.Serialization;

namespace KendoEmailAppSharp.Models;

/// <summary>
/// Represents a phone number and its associated credit.
/// </summary>
public record KendoPhone 
{
    [JsonPropertyName("phone")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("credit")]
    public uint Credit { get; set; }
}