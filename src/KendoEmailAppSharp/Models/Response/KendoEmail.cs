using System.Text.Json.Serialization;

namespace KendoEmailAppSharp.Models;

/// <summary>
/// Represents an email object with private and work email addresses and a credit value.
/// </summary>
public record KendoEmail
{
    [JsonPropertyName("private_email")]
    public string? PrivateEmail { get; set; }

    [JsonPropertyName("work_email")]
    public string? WorkEmail { get; set; }

    [JsonPropertyName("credit")]
    public uint Credit { get; set; }
}