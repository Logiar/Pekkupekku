using System.Text.Json.Serialization;

namespace Pekkupekku.Shared.Steam;

public class ItemPlatforms
{
    [JsonPropertyName("windows")] public bool Windows { get; set; }
    [JsonPropertyName("mac")] public bool Mac { get; set; }
    [JsonPropertyName("linux")] public bool Linux { get; set; }
}