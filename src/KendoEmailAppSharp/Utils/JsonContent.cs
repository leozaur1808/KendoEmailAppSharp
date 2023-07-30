using System.Text;
using System.Text.Json;

namespace KendoEmailAppSharp.Utils;
/// <summary>
/// Provides HTTP content based on JSON serialization of an object.
/// </summary>
public class JsonContent : StringContent
{

    /// <summary>
    /// Creates an instance of <see cref="JsonContent"/> with the specified value serialized as JSON.
    /// </summary>
    /// <typeparam name="T">The type of the value to serialize.</typeparam>
    /// <param name="value">The value to serialize.</param>
    /// <returns>An instance of <see cref="JsonContent"/> with the specified value serialized as JSON.</returns>
    public static JsonContent Create<T>(T value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates an instance of <see cref="JsonContent"/> with the specified value serialized as JSON.
    /// </summary>
    /// <param name="content">Object to be serialized.</param>
    public JsonContent(object? content, JsonSerializerOptions? options = null) : base(
        content == null ? "" : JsonSerializer.Serialize(content, options),
        Encoding.UTF8,
        "application/json")
    { }
}
