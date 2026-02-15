import ChatSection from "./sections/ChatSection";
import PreviewSection from "./sections/PreviewSection";

function App() {
  return (
    <div className="overflow-hidden h-screen flex">
      <div className="flex-3">
        <PreviewSection />
      </div>
      <div className="flex-2">
        <ChatSection />
      </div>
    </div>
  );
}

export default App;
