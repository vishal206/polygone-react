import { ChatInput } from "@/components/ui/chatInput";
import { useEffect, useState } from "react";

export default function ChatSection() {
  const [text, setText] = useState("");

  useEffect(() => {
    if (text != "") {
      console.log("Text", text);
    }
  }, [text]);
  return (
    <div className="h-full w-full p-2 flex items-end">
      <ChatInput setText={setText} />
    </div>
  );
}
