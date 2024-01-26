import { LabelProps } from "@/hooks/use-label";
import { Color } from "@/types/nextui";
import { Input, InputProps } from "@nextui-org/react";

export interface LabeledInputProps {
  label: LabelProps;
  value: string;
  setValue: (message: string) => void;
  className?: string;
  inputProps?: InputProps;
  handleLabelProps?: HandleLabelProps;
}

export interface HandleLabelProps {
  setLabel: (color: Color, message: string) => void;
  isInputValid: (value: string) => boolean | null;
  successMessage: string;
  errorMessage: string;
}

export default function LabeledInput({
  label,
  value,
  setValue,
  className,
  inputProps: nextuiInputProps,
  handleLabelProps,
}: LabeledInputProps) {
  const handleLabel = ({
    setLabel,
    isInputValid,
    successMessage,
    errorMessage,
  }: HandleLabelProps) => {
    const isInputValueValid = isInputValid(value);
    if (value.length < 1) {
      setLabel("primary", "");
    } else if (isInputValueValid == null) {
      return;
    } else if (!isInputValueValid) {
      setLabel("danger", errorMessage);
    } else setLabel("success", successMessage);
    return isInputValueValid;
  };
  return (
    <div className={className}>
      <label className={`text-${label.color}`}>{label.message}</label>
      <Input
        {...nextuiInputProps}
        isClearable={nextuiInputProps?.isClearable}
        variant={nextuiInputProps?.variant ?? "bordered"}
        color={nextuiInputProps?.color ?? label.color ?? "primary"}
        size={nextuiInputProps?.size ?? "md"}
        placeholder={nextuiInputProps?.placeholder}
        value={value}
        type={nextuiInputProps?.type}
        onChange={event => {
          setValue(event.target.value);
          if (nextuiInputProps?.onChange) nextuiInputProps.onChange(event);
          handleLabelProps?.setLabel("primary", "");
        }}
        onClear={() => {
          setValue("");
          if (nextuiInputProps?.onClear) nextuiInputProps.onClear();
        }}
        onBlur={event => {
          if (nextuiInputProps?.onBlur) nextuiInputProps.onBlur(event);
          if (handleLabelProps) handleLabel(handleLabelProps);
        }}
      />
    </div>
  );
}
