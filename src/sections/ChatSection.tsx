import { ChatInput } from "@/components/ui/chatInput";
import { useChat } from "@/contexts/ChatContexts";

export default function ChatSection() {
  const { conversations, userInput, isFetchingOutput, chatPosition } =
    useChat();

  if (!chatPosition) return null;

  const panelWidth = 384; // w-96 = 24rem = 384px
  const panelHeight = 288; // h-72 = 18rem = 288px
  const padding = 12; // small gap from edge

  const maxX = window.innerWidth - panelWidth - padding;
  const maxY = window.innerHeight - panelHeight - padding;

  const x = Math.min(chatPosition.x, maxX);
  const y = Math.min(chatPosition.y, maxY);

  return (
    <div
      className="fixed h-72 w-96 p-2 flex flex-col justify-end text-black bg-gray-400 transition-all duration-150 ease-out rounded-3xl"
      style={{ left: x, top: y }}
    >
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
