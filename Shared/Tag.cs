using System.Text.Json.Serialization;

namespace Pekkupekku.Shared;

public class Tag
{
    [JsonPropertyName("tagid")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;
}