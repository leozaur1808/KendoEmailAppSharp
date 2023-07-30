using System.Text.Json.Serialization;

namespace KendoEmailAppSharp.Models;

/// <summary>
/// Represents a lead in the KendoEmailAppSharp application.
/// </summary>
public record KendoLead
{
    [JsonPropertyName("firstname")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastname")]
    public string? LastName { get; set; }

    [JsonPropertyName("linkedin")]
    public string? LinkedIn { get; set; }

    [JsonPropertyName("personal_email")]
    public string? PersonalEmail { get; set; }

    [JsonPropertyName("work_email")]
    public string? WorkEmail { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}