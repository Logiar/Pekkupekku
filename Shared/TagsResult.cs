using System.Text.Json.Serialization;

namespace Pekkupekku.Shared;

public class TagsResult
{
    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; } = new ();
    [JsonPropertyName("success")]
    public int Success { get; set; }

    public Tag this[int i]
    {
        get => Tags[i];
        set => Tags[i] = value;
    }
}