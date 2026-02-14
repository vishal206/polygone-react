namespace server.Services;

using System.Text.Json;
using server.Models;
public interface IOllamaService
{
    Task<string> GenerateAsync(string prompt);
}

public class OllamaService(HttpClient httpClient) : IOllamaService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GenerateAsync(string prompt)
    {
        var request = new
        {
            model = "mistral",
            stream = false,
            format = "json",
            messages = new[]
            {
            new
            {
                role = "system",
                content = """
You are a strict backend code generator.

You MUST return valid JSON in this exact structure:

{
  "Code": "full JavaScript code here",
  "Message": "short status message"
}

Do not include markdown.
Do not include explanations.
Never output special tokens.
Never output tokenizer artifacts.
Only valid JavaScript syntax.
Return ONLY valid JSON.
"""
            },
            new
            {
                role = "user",
                content = prompt
            }
        },
            options = new
            {
                temperature = 0,
                top_p = 1,
                num_predict = 2048
            }
        };

        var response = await _httpClient.PostAsJsonAsync(
            "http://localhost:11434/api/chat",
            request
        );

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OllamaResponse>()
            ?? throw new Exception("Ollama returned null response.");

        // 🔥 IMPORTANT: For /api/chat, content is inside result.Message.Content
        var rawJson = result.Message?.Content
            ?? throw new Exception("Model did not return content.");

        Console.WriteLine(rawJson);

        var structured = JsonSerializer.Deserialize<GeneratedResult>(
            rawJson,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? throw new Exception("Invalid JSON from model.");

        if (string.IsNullOrWhiteSpace(structured.Code))
            throw new Exception("Model returned empty code.");

        return structured.Code;
    }

}

public class GeneratedResult
{
    public required string Code { get; set; }
    public required string Message { get; set; }
}