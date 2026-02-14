using server.Models;

namespace server.Services;

public static class AnimationService
{
    public static Animation GetDemoAnimation()
    {
        return new Animation
        {
            AnimationCode = """
            import { useGSAP } from "@gsap/react";
import gsap from "gsap";

function VerticalFlowchart() {
  useGSAP(() => {
    const tl = gsap.timeline({ repeat: -1, repeatDelay: 1 });

    // First box appears immediately
    tl.from("#box-1", {
      opacity: 0,
      y: 20,
      duration: 0.5,
      ease: "power3.out",
    });

    // Arrow 1 draws
    tl.to("#arrow-1", {
      strokeDashoffset: 0,
      duration: 0.6,
      ease: "power2.inOut",
    });

    // Box 2 appears AFTER arrow
    tl.from("#box-2", {
      opacity: 0,
      y: 20,
      duration: 0.5,
      ease: "power3.out",
    });

    tl.to("#arrow-2", {
      strokeDashoffset: 0,
      duration: 0.6,
      ease: "power2.inOut",
    });

    tl.from("#box-3", {
      opacity: 0,
      y: 20,
      duration: 0.5,
      ease: "power3.out",
    });

    tl.to("#arrow-3", {
      strokeDashoffset: 0,
      duration: 0.6,
      ease: "power2.inOut",
    });

    tl.from("#box-4", {
      opacity: 0,
      y: 20,
      duration: 0.5,
      ease: "power3.out",
    });

    tl.to("#arrow-4", {
      strokeDashoffset: 0,
      duration: 0.6,
      ease: "power2.inOut",
    });

    tl.from("#box-5", {
      opacity: 0,
      y: 20,
      duration: 0.5,
      ease: "power3.out",
    });
  }, []);

  return (
    <div className="w-screen h-screen flex items-center justify-center bg-slate-950 text-white">
      <div className="flex flex-col items-center">

        <FlowBox id="box-1" text="👤 User selects a tab" />

        <Arrow id="arrow-1" />

        <FlowBox id="box-2" text="🧭 Frontend sets active tab" />

        <Arrow id="arrow-2" />

        <FlowBox id="box-3" text="⚛️ State updates" />

        <Arrow id="arrow-3" />

        <FlowBox id="box-4" text="🌐 API request fired" />

        <Arrow id="arrow-4" />

        <FlowBox id="box-5" text="📦 Data received → UI rendered" />

      </div>
    </div>
  );
}

function FlowBox({ id, text }) {
  return (
    <div
      id={id}
      className="px-6 py-3 my-2 rounded-lg bg-slate-800 text-center min-w-[260px]"
    >
      {text}
    </div>
  );
}

function Arrow({ id }) {
  return (
    <svg width="40" height="48" viewBox="0 0 40 48">
      <line
        id={id}
        x1="20"
        y1="0"
        x2="20"
        y2="36"
        stroke="#22c55e"
        strokeWidth="3"
        strokeDasharray="36"
        strokeDashoffset="36"
      />
      <polygon points="14,36 26,36 20,46" fill="#22c55e" />
    </svg>
  );
}

export default VerticalFlowchart;

"""
        };
    }

    public static Animation CreateNewAnimation(string userDescription)
  {
    string prompt = $"""
      You are an expert frontend engineer and motion designer.

      Input:
      - userDescription: A natural language description of a frontend or system flow
        (example: "User clicks a tab, frontend updates state, API is called, data is rendered")

      Task:
      - Generate a React component using GSAP and @gsap/react
      - Export the component as a STRING assigned to a const
      - The animation must be a VERTICAL FLOWCHART

      Animation rules (VERY IMPORTANT):
      1. The layout must be full-screen safe (w-screen, h-screen, centered).
      2. The flow must be vertical (top → bottom).
      3. Each step must be represented as a box.
      4. Between every two boxes, render a downward arrow using SVG.
      5. ANIMATION SEQUENCE:
        - The first box appears.
        - THEN the arrow below it animates (strokeDashoffset from full to 0).
        - ONLY AFTER the arrow finishes, the next box appears.
        - Repeat this pattern for all steps.
      6. No play/pause buttons. The animation auto-runs and loops.
      7. Use Tailwind CSS utility classes for styling.
      8. Use GSAP timeline for strict sequencing.
      9. Keep the code readable and minimal — no unnecessary abstractions.

      Code requirements:
      - Use useGSAP from "@gsap/react"
      - Use gsap.timeline()
      - Use unique IDs for boxes and arrows (box-1, arrow-1, etc.)
      - Export format must be:

        export const GENERATED_GSAP_CODE = \`
          ...full React component code...
        \`;

      Output:
      - Return ONLY the code string
      - Do NOT include explanations
      - Do NOT include markdown
      - Do NOT include comments outside the code
      - The code must be directly runnable inside a React app

      Now generate the GSAP animation code based on this userDescription:
      {userDescription}
    """;

    var code = LangChainService.GenerateAnimationCode(prompt);

    return new Animation
    {
        AnimationCode = code.Result 
    };
  }
}
