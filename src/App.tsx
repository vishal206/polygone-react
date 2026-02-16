import { ChatProvider } from "./contexts/ChatContexts";
import ChatSection from "./sections/ChatSection";
import PreviewSection from "./sections/PreviewSection";

function App() {
  return (
    <ChatProvider>
      <div className="overflow-hidden h-screen flex">
        <div className="flex-3">
          <PreviewSection />
        </div>
        <div className="flex-2">
          <ChatSection />
        </div>
      </div>
    </ChatProvider>
  );
}

export default App;
