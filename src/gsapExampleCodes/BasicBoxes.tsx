import gsap from "gsap";
import { useGSAP } from "@gsap/react";

function BasicBoxes() {
  // const box = useRef();

  useGSAP(() => {
    gsap.to("#blue-box", {
      x: 250, // x - 0 to 250px
      repeat: -1, // repeat indefinitely
      yoyo: true, // reverse the animation on every other repeat
      duration: 4, // duration of 10 seconds
      rotation: 360, // rotate 360 degrees
    });

    gsap.from("#green-box", {
      x: -250, // x - 0 to 250px
      repeat: -1, // repeat indefinitely
      yoyo: true, // reverse the animation on every other repeat
      duration: 4, // duration of 10 seconds
      rotation: 360, // rotate 360 degrees
    });

    gsap.fromTo(
      "#yellow-box",
      {
        x: -250, // x - 0 to 250px
        rotation: 0, // rotate 360 degrees
      },
      {
        x: 250, // x - 0 to 250px
        repeat: -1, // repeat indefinitely
        yoyo: true, // reverse the animation on every other repeat
        duration: 4, // duration of 10 seconds
        rotation: 360, // rotate 360 degrees
      },
    );
  }, []);

  return (
    <div className="flex flex-col items-center justify-center h-screen">
      <div id="blue-box" className="w-20 h-20 bg-blue-500 rounded-lg" />
      <div id="green-box" className="w-20 h-20 bg-green-500 rounded-lg" />
      <div id="yellow-box" className="w-20 h-20 bg-yellow-500 rounded-lg" />
    </div>
  );
}

export default BasicBoxes;
