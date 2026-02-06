import { useGSAP } from "@gsap/react";
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
      <button
        className="px-4 py-2 bg-blue-500 text-white rounded"
        onClick={() => {
          if (timeline.paused()) {
            timeline.play();
          } else {
            timeline.pause();
          }
        }}
      >
        Play Timeline
      </button>

      <div id="yellow-box" className="w-20 h-20 bg-yellow-500" />
    </div>
  );
}

export default GsapTimeline;
