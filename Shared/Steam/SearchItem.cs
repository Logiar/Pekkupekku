using System.Text.Json.Serialization;

namespace Pekkupekku.Shared.Steam;

public class SearchItem
{
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("price")] public ItemPrice? Price { get; set; }
    [JsonPropertyName("tiny_image")] public string TinyImage { get; set; } = string.Empty;
    [JsonPropertyName("metascore")] public string Metascore { get; set; } = string.Empty;
    [JsonPropertyName("platforms")] public ItemPlatforms? Platforms { get; set; }
    [JsonPropertyName("streamingvideo")] public bool StreamingVideo { get; set; }
    [JsonPropertyName("controller_support")] public string? ControllerSupport { get; set; }

}