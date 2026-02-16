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

  useEffect(() => {
    if (aiOutput) {
      console.log("AiOutput:", aiOutput);
      setConversations([
        ...conversations,
        {
          user: userInput,
          ai: aiOutput,
        },
      ]);
    }
  }, [aiOutput]);

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
      }}
    >
      {children}
    </ChatContext.Provider>
  );
};

export const useChat = () => {
  return useContext(ChatContext);
};
