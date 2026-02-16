import { ChatInput } from "@/components/ui/chatInput";
import { useChat } from "@/contexts/ChatContexts";

export default function ChatSection() {
  const { conversations, userInput, isFetchingOutput } = useChat();
  return (
    <div className="h-full w-full p-2 flex flex-col justify-end text-black">
      <div className="flex flex-col">
        {isFetchingOutput && (
          <div className="flex flex-col">
            <div>User: {userInput} </div>
            <div>Ai: ....</div>
          </div>
        )}
        {!isFetchingOutput && conversations.length > 0 && (
          <div className="flex flex-col gap-4">
            {conversations.map((conversation: any, index: number) => (
              <div key={index}>
                <div>User: {conversation.user}</div>
                <div>AI: {conversation.ai.aiMessage}</div>
              </div>
            ))}
          </div>
        )}
      </div>
      <>
        <ChatInput />
      </>
    </div>
  );
}
