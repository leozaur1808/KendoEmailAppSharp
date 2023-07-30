using System.Text.Json.Serialization;

namespace KendoEmailAppSharp.Models;

/// <summary>
/// Represents information about a lead, including lead count, executive count, similar domains, lead countries, domain, description, Crunchbase URL, Twitter URL, industry, size, and company name.
/// </summary>
public record KendoLeadsInfo
{
    [JsonPropertyName("leadcount")]
    public int LeadCount { get; set; }

    [JsonPropertyName("executivecount")]
    public int ExecutiveCount { get; set; }

    [JsonPropertyName("similardomains")]
    public string[]? SimilarDomains { get; set; }

    [JsonPropertyName("leadscountries")]
    public string[]? LeadsCountries { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("crunchbaseurl")]
    public string? CrunchbaseUrl { get; set; }

    [JsonPropertyName("twitterurl")]
    public string? TwitterUrl { get; set; }

    [JsonPropertyName("industry")]
    public string? Industry { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("company")]
    public string? CompanyName { get; set; }
}