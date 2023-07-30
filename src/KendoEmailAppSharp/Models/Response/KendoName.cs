using System.Text.Json.Serialization;

namespace KendoEmailAppSharp.Models;

/// <summary>
/// Represents a person's name.
/// </summary>
public record KendoName
{
    [JsonPropertyName("first")]
    public string? First { get; set; }

    [JsonPropertyName("last")]
    public string? Last { get; set; }

    [JsonPropertyName("credit")]
    public uint Credit { get; set; }
}