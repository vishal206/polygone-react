using server.Models;

namespace server.Services;

public static class LangChainService
{
    // NEW conversation
    public static async Task<string> GenerateAnimationCode(string prompt)
    {
        // 🔹 Call LangChain here
        // 🔹 No animation logic here
        await Task.Delay(200); // mock

        return "// React animation code from LangChain (new conversation)";
    }

    // EXISTING conversation
    public static async Task<string> GenerateAnimationCodeWithContextAsync(
        string prompt,
        ConversationContext context)
    {
        // 🔹 Send context + prompt to LangChain
        await Task.Delay(200); // mock

        return "// React animation code from LangChain (with context)";
    }
}
