namespace server.Models;

public class ConversationContext
{
    public required string ConversationId { get; set; }
    public List<string> Messages { get; set; } = [];
}
