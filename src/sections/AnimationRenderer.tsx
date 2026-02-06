import { useRef } from "react";
import { useGSAP } from "@gsap/react";
import gsap from "gsap";
import type { AnimationSpec } from "../utils/types";

export function AnimationRenderer({ spec }: { spec: AnimationSpec }) {
  const container = useRef<HTMLDivElement>(null);

  useGSAP(
    () => {
      spec.timeline.forEach(
        ({ target, from, to, duration, repeat, yoyo, ease, delay }) => {
          const element = container.current?.querySelector(
            target,
          ) as HTMLElement;
          if (element) {
            gsap.fromTo(element, from || {}, {
              ...to,
              duration,
              repeat,
              yoyo,
              ease,
              delay,
            });
          }
        },
      );
    },
    { scope: container },
  );

  return (
    <div
      ref={container}
      className={`w-full h-screen ${spec.layout} ${spec.background}`}
    >
      {spec.elements.map(({ id, className, style }) => (
        <div key={id} id={id} className={className} style={style} />
      ))}
    </div>
  );
}
export default AnimationRenderer;
