export const GSAP_TIMELINE_DEMO_CODE = `import { useGSAP } from "@gsap/react";
import gsap from "gsap";

function GsapTimeline() {
  const timeline = gsap.timeline({
    repeat: -1, // repeat indefinitely
    yoyo: true, // reverse the animation on every other repeat
    repeatDelay: 1, // delay of 1 second between repeats
  });

  useGSAP(() => {
    timeline.to("#yellow-box", {
      x: 250, // x - 0 to 250px
      duration: 2, // duration of 2 seconds
      rotation: 360, // rotate 360 degrees
      borderRadius: "100%", // change border radius to 100%
      ease: "back.inOut",
    });

    timeline.to("#yellow-box", {
      x: 0, // x - 0 to 250px
      duration: 2, // duration of 2 seconds
      rotation: 360, // rotate 360 degrees
      borderRadius: "0", // change border radius to 100%
      ease: "back.inOut",
    });
  }, []);
  return (
    <div className="space-y-20">

      <div id="yellow-box" className="w-20 h-20 bg-yellow-500" />
    </div>
  );
}

export default GsapTimeline;
`;

export const GSAP_TAB_API_FLOWCHART_CODE = `import { useGSAP } from "@gsap/react";
import gsap from "gsap";

function TabApiFlowchart() {
  useGSAP(() => {
    const tl = gsap.timeline({ repeat: -1, repeatDelay: 1 });

    tl.from(".box", {
      opacity: 0,
      y: 30,
      duration: 0.6,
      stagger: 0.3,
      ease: "power3.out",
    });

    tl.to(".arrow-line", {
      strokeDashoffset: 0,
      duration: 0.8,
      stagger: 0.2,
      ease: "power2.inOut",
    });
  }, []);

  return (
    <div className="w-screen h-screen flex items-center justify-center bg-slate-950 text-white">
      <div className="flex flex-col items-center space-y-4">

        <div className="box px-6 py-3 rounded-lg bg-slate-800">
          👤 User selects a tab
        </div>

        <Arrow />

        <div className="box px-6 py-3 rounded-lg bg-blue-600">
          🧭 Frontend sets active tab
        </div>

        <Arrow />

        <div className="box px-6 py-3 rounded-lg bg-slate-800">
          ⚛️ State updates (useState / store)
        </div>

        <Arrow />

        <div className="box px-6 py-3 rounded-lg bg-slate-800">
          🌐 API request fired
        </div>

        <Arrow />

        <div className="box px-6 py-3 rounded-lg bg-green-600">
          📦 Data received → UI rendered
        </div>

      </div>
    </div>
  );
}

function Arrow() {
  return (
    <svg width="40" height="40" viewBox="0 0 40 40">
      <line
        x1="20"
        y1="0"
        x2="20"
        y2="32"
        stroke="#22c55e"
        strokeWidth="3"
        strokeDasharray="32"
        strokeDashoffset="32"
        className="arrow-line"
      />
      <polygon
        points="14,28 26,28 20,38"
        fill="#22c55e"
      />
    </svg>
  );
}

export default TabApiFlowchart;
`;
