namespace server.Models;

public class OllamaResponse
{
    public required string Model { get; set; }
    public required OllamaMessage Message { get; set; }
}

public class OllamaMessage
{
    public required string Role { get; set; }
    public required string Content { get; set; }
}