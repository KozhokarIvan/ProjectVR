import { Color } from "@/types/nextui";
import { useCallback, useState } from "react";

export interface LabelProps {
  color: Color;
  message: string;
}

export const useLabel: (
  initialColor: Color,
  initialMessage: string
) => [ss: LabelProps, sss: (color: Color, message: string) => void] = (
  initialColor: Color,
  initialMessage: string
) => {
  const [color, setColor] = useState<Color>(initialColor);
  const [message, setMessage] = useState<string>(initialMessage);
  const setLabel = useCallback((color: Color, message: string) => {
    setColor(() => color);
    setMessage(() => message);
  }, []);
  const label: LabelProps = { color: color, message: message };
  return [label, setLabel];
};
