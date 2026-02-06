import type { AnimationSpec } from "./types";

export const DEMO_SPEC: AnimationSpec = {
  timeline: [
    {
      id: "blue-box",
      target: "#blue-box",
      from: { x: 0, opacity: 0 },
      to: { x: 250, opacity: 1, rotation: 360 },
      duration: 4,
      repeat: -1,
      yoyo: true,
      ease: "power2.out",
    },
    {
      id: "green-box",
      target: "#green-box",
      to: { x: 250, rotation: 360 },
      duration: 4,
      repeat: -1,
      yoyo: true,
    },
    {
      id: "yellow-box",
      target: "#yellow-box",
      from: { x: -250, rotation: 0, borderRadius: "100%" },
      to: { x: 250, rotation: 360, borderRadius: "8px" },
      duration: 4,
      repeat: -1,
      yoyo: true,
    },
  ],
  elements: [
    { id: "blue-box", className: "w-20 h-20 bg-blue-500 rounded-lg" },
    { id: "green-box", className: "w-20 h-20 bg-green-500 rounded-lg" },
    { id: "yellow-box", className: "w-20 h-20 bg-yellow-500 rounded-lg" },
  ],
  layout: "flex flex-col items-center justify-center",
  background: "bg-gradient-to-br from-slate-900 to-blue-900",
};
