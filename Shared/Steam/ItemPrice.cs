using System.Text.Json.Serialization;

namespace Pekkupekku.Shared.Steam;

public class ItemPrice
{
    [JsonPropertyName("currency")] public string Currency { set; get; } = string.Empty;
    [JsonPropertyName("initial")] public int Initial { set; get; }
    [JsonPropertyName("final")] public int Final { set; get; }
}