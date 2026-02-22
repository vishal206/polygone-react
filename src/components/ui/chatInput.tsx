"use client";

import {
  InputGroup,
  InputGroupAddon,
  InputGroupButton,
} from "@/components/ui/input-group";
import { useChat } from "@/contexts/ChatContexts";
import { useState } from "react";
import TextareaAutosize from "react-textarea-autosize";

export function ChatInput() {
  const [value, setValue] = useState("");
  const { setUserInput, setRequestId } = useChat();

  const handleSubmit = () => {
    if (!value.trim()) return;
    setUserInput(value); // send text to parent
    setRequestId((prev: number) => prev + 1);
    setValue(""); // clear textarea
  };
  return (
    <div className="grid w-full gap-6">
      <InputGroup>
        <TextareaAutosize
          data-slot="input-group-control"
          className="flex field-sizing-content w-full resize-none rounded-md bg-transparent px-3 py-2.5 text-base transition-[color,box-shadow] outline-none md:text-sm"
          placeholder="Autoresize textarea..."
          value={value}
          onChange={(e) => setValue(e.target.value)}
        />
        <InputGroupAddon align="block-end">
          <InputGroupButton
            className="ml-auto"
            size="sm"
            variant="default"
            onClick={handleSubmit}
          >
            Submit
          </InputGroupButton>
        </InputGroupAddon>
      </InputGroup>
    </div>
  );
}
