import {
  SandpackLayout,
  SandpackPreview,
  SandpackProvider,
} from "@codesandbox/sandpack-react";
import { useEffect, useState } from "react";

function App() {
  const [animationCode, setAnimationCode] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("/ai/demo-code")
      .then((res) => res.json())
      .then((data) => {
        setAnimationCode(data.animationCode);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Failed to load demo code", err);
        setLoading(false);
      });
  }, []);

  useEffect(() => {
    console.log("Received animation code:", animationCode);
  }, [animationCode]);

  if (loading) {
    return (
      <div className="h-screen flex items-center justify-center text-white bg-black">
        Loading animation…
      </div>
    );
  }

  return (
    <div className="overflow-hidden h-screen">
      <SandpackProvider
        template="react"
        options={{
          externalResources: ["https://cdn.tailwindcss.com"],
        }}
        customSetup={{
          dependencies: {
            react: "^18.2.0",
            "react-dom": "^18.2.0",
            gsap: "^3.12.5",
            "@gsap/react": "^2.1.0",
          },
        }}
        style={{ height: "100vh" }}
        files={{
          "/App.js": animationCode,
        }}
      >
        <SandpackLayout style={{ height: "100vh" }}>
          <SandpackPreview style={{ height: "100vh" }} />
        </SandpackLayout>
      </SandpackProvider>
    </div>
  );
}

export default App;
