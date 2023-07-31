using System.Text.Json;
using System.Net.Http.Headers;

namespace KendoEmailAppSharp.Utils;


/// <summary>
/// Provides a base class for REST APIs that communicate using JSON.
/// </summary>
public abstract class JsonRestApi: IDisposable
{
    /// <summary>
    /// The base address of the API.
    /// </summary>
    protected Uri BaseAddress { get; }

    /// <summary>
    /// The HTTP client to use.
    /// </summary>
    protected HttpClient Client { get;}

    /// <summary>
    /// The options to use when serializing and deserializing JSON.
    /// </summary>
    private static readonly JsonSerializerOptions options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
    };

    /// <summary>
    /// Provides a base class for REST APIs that communicate using JSON.
    /// </summary>
    /// <param name="baseAddress">The base address of the API.</param>
    /// <param name="handler">The HTTP message handler to use.</param>
    /// <param name="apiKey">The API key to use.</param>
    protected JsonRestApi(string baseAddress, HttpMessageHandler? handler = null)
    {
        BaseAddress = new Uri(baseAddress);
        Client = handler == null ? new HttpClient() : new HttpClient(handler: handler);
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <summary>
    /// Sends a GET request to the specified path and returns the response deserialized as an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize the response to.</typeparam>
    /// <param name="path">The path to send the GET request to.</param>
    /// <returns>The deserialized response as an object of type T.</returns>
    protected async Task<T?> GetAsync<T>(string path, Dictionary<string, string>? queryParams = null) where T : class
    {
        path = AddQueryParams(path, queryParams);
        HttpResponseMessage response = await Client.GetAsync(new Uri(BaseAddress, path));
        response.EnsureSuccessStatusCode();
        return await ParseJson<T>(response);
    }

    /// <summary>
    /// Sends a POST request to the specified path with the given body and returns the response deserialized as an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize the response to.</typeparam>
    /// <param name="path">The path to send the POST request to.</param>
    /// <param name="body">The body of the POST request.</param>
    /// <returns>The deserialized response as an object of type T.</returns>
    protected async Task<T?> PostAsync<T>(string path, object body, Dictionary<string, string>? queryParams = null) where T : class
    {
        path = AddQueryParams(path, queryParams);
        HttpResponseMessage response = await Client.PostAsync(new Uri(BaseAddress, path), JsonContent.Create(body));
        response.EnsureSuccessStatusCode();
        return await ParseJson<T>(response);
    }

    /// <summary>
    /// Sends a PUT request to the specified path with the given body and returns the response deserialized as an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize the response to.</typeparam>
    /// <param name="path">The path to send the PUT request to.</param>
    /// <param name="body">The body of the PUT request.</param>
    /// <returns>The deserialized response as an object of type T.</returns>
    protected async Task<T?> PutAsync<T>(string path, object body, Dictionary<string, string>? queryParams = null) where T : class
    {
        path = AddQueryParams(path, queryParams);
        HttpResponseMessage response = await Client.PutAsync(new Uri(BaseAddress, path), JsonContent.Create(body));
        response.EnsureSuccessStatusCode();
        return await ParseJson<T>(response);
    }

    /// <summary>
    /// Sends a DELETE request to the specified path and returns the response deserialized as an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize the response to.</typeparam>
    /// <param name="path">The path to send the DELETE request to.</param>
    /// <returns>The deserialized response as an object of type T.</returns>
    protected async Task<T?> DeleteAsync<T>(string path, Dictionary<string, string>? queryParams = null) where T : class
    {
        path = AddQueryParams(path, queryParams);
        HttpResponseMessage response = await Client.DeleteAsync(new Uri(BaseAddress, path));
        response.EnsureSuccessStatusCode();
        return await ParseJson<T>(response);
    }

    /// <summary>
    /// Parses the JSON content of the specified HTTP response message and deserializes it as an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize the JSON content to.</typeparam>
    /// <param name="responseMessage">The HTTP response message to parse.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="responseMessage"/> is null.</exception>
    /// <returns>The deserialized object of type T.</returns>
    private static async Task<T?> ParseJson<T>(HttpResponseMessage responseMessage) where T : class
    {
        if (responseMessage is null)
        {
            throw new ArgumentNullException(nameof(responseMessage));
        }
        string content = await responseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content, options);
    }


    /// <summary>
    /// Adds the specified query parameters to the given path and returns the resulting URL.
    /// </summary>
    /// <param name="path">The path to add the query parameters to.</param>
    /// <param name="queryParams">The query parameters to add to the path.</param>
    /// <returns>The resulting URL with the added query parameters.</returns>
    protected virtual string AddQueryParams(string path, Dictionary<string, string>? queryParams)
    {
        if (queryParams is null || queryParams.Count == 0)
        {
            return path;
        }
        string queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return path + $"?{queryString}";
    }

    /// <summary>
    /// Disposes the HTTP client.
    /// </summary>
    public void Dispose()
    {
        Client.Dispose();
    }
}