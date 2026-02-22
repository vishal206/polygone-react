import {
  createContext,
  useContext,
  useEffect,
  useState,
  type ReactNode,
} from "react";

type ChatProviderProps = {
  children: ReactNode;
};

type ConversationProps = {
  user: string;
  ai: aiMessageProp;
};

type aiMessageProp = {
  aiMessage: string;
  aiCode: string;
};

const ChatContext = createContext<any>(null);

export const ChatProvider = ({ children }: ChatProviderProps) => {
  const [userInput, setUserInput] = useState("");
  const [aiOutput, setAiOutput] = useState<aiMessageProp>();
  const [isFetchingOutput, setIsFetchingOutput] = useState(false);
  const [conversations, setConversations] = useState<ConversationProps[]>([]);
  const [requestId, setRequestId] = useState(0);
  const [chatPosition, setChatPosition] = useState<
    | {
        x: number;
        y: number;
      }
    | undefined
  >();

  useEffect(() => {
    if (aiOutput) {
      setConversations((prev) => [
        ...prev,
        {
          user: userInput,
          ai: aiOutput,
        },
      ]);
    }
  }, [aiOutput, userInput]);

  return (
    <ChatContext.Provider
      value={{
        userInput,
        setUserInput,
        aiOutput,
        setAiOutput,
        conversations,
        isFetchingOutput,
        setIsFetchingOutput,
        chatPosition,
        setChatPosition,
        requestId,
        setRequestId,
      }}
    >
      {children}
    </ChatContext.Provider>
  );
};

export const useChat = () => {
  return useContext(ChatContext);
};
