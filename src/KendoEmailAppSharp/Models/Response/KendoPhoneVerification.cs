using System.Text.Json.Serialization;

namespace KendoEmailAppSharp.Models;

/// <summary>
/// Represents a phone verification record.
/// </summary>
public record KendoPhoneVerification
{

    [JsonPropertyName("results")]
    public string? Results { get; set; }

    [JsonPropertyName("credit")]
    public uint Credit { get; set; }
}