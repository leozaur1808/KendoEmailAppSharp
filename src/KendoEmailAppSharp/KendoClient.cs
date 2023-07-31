using KendoEmailAppSharp.Utils;

namespace KendoEmailAppSharp;

public partial class KendoClient : JsonRestApi, IKendo
{
    private readonly string apiKey;
    public KendoClient(string apiKey, HttpMessageHandler? handler = null) : base("https://kendoemailapp.com", handler)
    {
        this.apiKey = apiKey;
    }

    /// <summary>
    /// Adds the "apikey" query parameter to the given path and query parameters dictionary.
    /// If the query parameters dictionary is null, creates a new dictionary with the "apikey" parameter.
    /// </summary>
    /// <param name="path">The path to add the query parameters to.</param>
    /// <param name="queryParams">The dictionary of query parameters to add the "apikey" parameter to.</param>
    /// <returns>The path with the added "apikey" query parameter.</returns>
    protected override string AddQueryParams(string path, Dictionary<string, string>? queryParams = null)
    {
        if (queryParams is not null)
        {
            queryParams.Add("apikey", apiKey);
        }
        else
        {
            queryParams = new Dictionary<string, string> { { "apikey", apiKey } };
        }
        return base.AddQueryParams(path, queryParams);
    }
}