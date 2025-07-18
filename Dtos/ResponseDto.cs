using System.Text.Json.Serialization;

namespace Dtos;

public class ResponseDto
{
    [JsonPropertyName("content")]
    public object? Content { get; set; }
    
    [JsonPropertyName("executionSuccessful")]
    public bool ExecutionSuccessful { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}