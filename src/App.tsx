import {
  SandpackCodeEditor,
  SandpackFileExplorer,
  SandpackLayout,
  SandpackPreview,
  SandpackProvider,
} from "@codesandbox/sandpack-react";

function App() {
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
      >
        <SandpackLayout style={{ height: "100vh" }}>
          <SandpackFileExplorer style={{ height: "100vh" }} />
          <SandpackCodeEditor style={{ height: "100vh" }} />
          <SandpackPreview style={{ height: "100vh" }} />
        </SandpackLayout>
      </SandpackProvider>
    </div>
  );
}

export default App;
