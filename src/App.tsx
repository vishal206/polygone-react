import {
  SandpackLayout,
  SandpackPreview,
  SandpackProvider,
} from "@codesandbox/sandpack-react";
import { GSAP_VERTICAL_FLOWCHART_CODE } from "./utils/constants";

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
        files={{
          "/App.js": GSAP_VERTICAL_FLOWCHART_CODE,
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
