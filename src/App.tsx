import AnimationRenderer from "./sections/AnimationRenderer";
import { DEMO_SPEC } from "./utils/constants";

function App() {
  return (
    <div className="flex flex-col items-center justify-center h-screen">
      <AnimationRenderer spec={DEMO_SPEC} />
    </div>
  );
}

export default App;
