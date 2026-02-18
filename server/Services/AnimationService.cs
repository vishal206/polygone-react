namespace server.Services;

using server.Models;
using System.Text.RegularExpressions;


public interface IAnimationService
{
  Task<Animation> CreateNewAnimation(string userDescription);
}


public partial class AnimationService(IOpenAiService openAIService) : IAnimationService
{

  private readonly IOpenAiService _openAiService = openAIService;

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

""",
      AnimationResponseMessage = "Demo Code fetched."
    };
  }

  public async Task<Animation> CreateNewAnimation(string userDescription)
  {
    string prompt = $$"""
    # ROLE
    You are a deterministic React + GSAP code generator.

    You do NOT behave like a conversational assistant.
    You do NOT explain.
    You do NOT apologize.
    You ONLY output valid JavaScript code.

    # INPUT
    userDescription:
    "{{userDescription}}"

    # OBJECTIVE
    Generate a full React component that visualizes the animation from userDescription using GSAP.

    # STRUCTURE REQUIREMENTS (MANDATORY)

    1. The flow must represent the logical sequence of events described in userDescription.
    2. Each logical step must be rendered as a visual box.
    3. The layout must be full screen using:
      className="w-screen h-screen flex items-center justify-center"
    4. The inner container must use:
      className="flex flex-col items-center"
    5. Each div must have a unique id.

    # ANIMATION RULES (STRICT AND GLOBAL)

    - Use useGSAP from "@gsap/react" and gsap from "gsap".
    - always use timeline.
    - Use `timeline = gsap.timeline(...)` not `timeline = useGSAP(gsap.timline(...)`
    - The animation must auto-loop.
    - No buttons.
    - No user interaction.
    - No simplification to a single animated element.

    useGSAP:
    React hook from "@gsap/react" that runs GSAP animations with automatic context scoping and cleanup.  
    Syntax: useGSAP(callback, { scope, dependencies, revertOnUpdate })  
    • scope → ref for selector scoping  
    • dependencies → re-run control  
    • revertOnUpdate → auto cleanup on update  

    gsap.timeline():
    Creates a sequenced animation controller for multiple tweens.  
    Syntax: gsap.timeline({ defaults, delay, paused, repeat, repeatDelay, yoyo })  
    • defaults → shared tween properties  
    • paused → start paused  
    • repeat / repeatDelay → loop control  
    • yoyo → reverse on repeat  
    Methods: to(), from(), fromTo(), set(), add(), play(), pause(), reverse()
      - In methods like to(), from(), use the #ID directly, don't use gsap.select()

    - useGSAP must be used instead of React.useEffect.
    - The selector used in timeline must exactly match an element rendered in JSX.
    - Do NOT animate non-existing selectors.
    - Do NOT store timeline in a DOM ref.

    # CODE REQUIREMENTS

    The output MUST:

    - Start EXACTLY with:
      import { useGSAP } from "@gsap/react";
      import gsap from "gsap";
      import React from "react";

    - Define exactly one main React component (any valid function name).
    - Use Tailwind CSS utility classes.
    - End with:
      export default <MainComponentName>;

    You MUST return a valid JSON object with EXACTLY this structure:

    {
      "Code": "<FULL REACT COMPONENT CODE AS STRING>",
      "Message": "<Message for the User>"
    }

    # OUTPUT CONTRACT (CRITICAL)

    - Output ONLY raw JavaScript / React code.
    - Do NOT include markdown.
    - Do NOT include ```jsx or ```javascript.
    - Do NOT include JSON.
    - Do NOT include explanations.
    - Do NOT include commentary.
    - Do NOT include any text before the first import.
    - Do NOT include any text after export default.

    If anything outside valid JavaScript code is included, the output is invalid.
    """;


    var generatedMessage = await _openAiService.GenerateAsync(prompt);
    var cleanedCode = MyRegex().Replace(generatedMessage.Code, "").Replace("```", "").Trim();


    return new Animation
    {
      AnimationCode = cleanedCode,
      AnimationResponseMessage = generatedMessage.Message
    };
  }

  [GeneratedRegex(@"```[a-zA-Z]*")]
  private static partial Regex MyRegex();
}
