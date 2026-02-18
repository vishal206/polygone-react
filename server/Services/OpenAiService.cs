namespace server.Services;

using server.Models;
using OpenAI;
using OpenAI.Chat;
using System.Text.Json;

public interface IOpenAiService
{
    Task<GeneratedResult> GenerateAsync(string prompt);
}


public class OpenAiService : IOpenAiService
{
    private readonly ChatClient _chatClient;

    public OpenAiService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"];

        if (string.IsNullOrEmpty(apiKey))
            throw new ArgumentException("OpenAI API key is missing.");

        var client = new OpenAIClient(apiKey);

        _chatClient = client.GetChatClient("gpt-4.1-mini");
    }

    public async Task<GeneratedResult> GenerateAsync(string prompt)
    {
        var response = await _chatClient.CompleteChatAsync(
            [
                ChatMessage.CreateSystemMessage("You are a deterministic code generator that outputs strict JSON only."),
                ChatMessage.CreateUserMessage(prompt)
            ],
            new ChatCompletionOptions
            {
                Temperature = 0,
                ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat()
            });

        var rawContent = response.Value.Content[0].Text;

        try
        {
            var parsed = JsonSerializer.Deserialize<GeneratedResult>(
                rawContent,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (parsed == null)
            {
                return new GeneratedResult
                {
                    Code = "",
                    Message = "Invalid JSON response"
                };
            }

            return parsed;
        }
        catch
        {
            return new GeneratedResult
            {
                Code = "",
                Message = "Failed to parse AI response"
            };
        }
    }
}