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
}
