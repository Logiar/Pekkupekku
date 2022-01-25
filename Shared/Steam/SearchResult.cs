using System.Text.Json.Serialization;

namespace Pekkupekku.Shared.Steam;

public class SearchResult
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("items")] public List<SearchItem> Items { get; set; } = new();
}