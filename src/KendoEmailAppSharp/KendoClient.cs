using KendoEmailAppSharp.Utils;

namespace KendoEmailAppSharp;

public partial class KendoClient : JsonRestApi, IKendo
{
    private readonly string apiKey;
    public KendoClient(string apiKey, HttpMessageHandler? handler = null) : base("https://kendoemailapp.com", handler)
    {
        this.apiKey = apiKey;
    }

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