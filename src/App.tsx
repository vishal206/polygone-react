import { useChat } from "./contexts/ChatContexts";
import ChatSection from "./sections/ChatSection";
import PreviewSection from "./sections/PreviewSection";

function App() {
  const { chatPosition, setChatPosition, requestId } = useChat();

  const handleClick = (e: React.MouseEvent) => {
    setChatPosition({
      x: e.clientX,
      y: e.clientY,
    });
  };
  return (
    <div className="overflow-hidden h-screen bg-gray-100">
      <div className="h-full">
        {requestId === 0 ? (
          <div
            className="flex justify-center items-center h-full"
            onClick={handleClick}
          >
            Welcome to polygone
          </div>
        ) : (
          <div className="">
            <PreviewSection />
            {/* Transparent overlay */}
            <div onClick={handleClick} className="absolute inset-0 z-10" />
          </div>
        )}
      </div>
      {chatPosition && (
        <div className="">
          <ChatSection />
        </div>
      )}
    </div>
  );
}

export default App;
