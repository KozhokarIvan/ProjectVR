import { LabelProps } from "@/hooks/use-label";
import { MutableRefObject } from "react";
import LabeledInput from "./LabeledInput";
import { Color } from "@/types/nextui";
import { InputProps } from "@nextui-org/react";

export interface ConfirmedPasswordInputProps {
  setIsConfirmedPasswordValid: (value: boolean) => void;
  confirmedPassword: string;
  setConfirmedPassword: (password: string) => void;
  handlePasswordsEquality: () => boolean | null;
  confirmedPasswordLabel: LabelProps;
  setConfirmedPasswordLabel: (color: Color, message: string) => void;
  className?: string;
  inputProps?: InputProps;
}

export default function ConfirmedPasswordInput({
  setIsConfirmedPasswordValid: setIsConfirmedPasswordValid,
  confirmedPassword,
  setConfirmedPassword,
  handlePasswordsEquality,
  confirmedPasswordLabel,
  setConfirmedPasswordLabel,
  className,
  inputProps,
}: ConfirmedPasswordInputProps) {
  const successMessage = "Passwords match";
  const errorMessage = "*Passwords don't match";
  const isConfirmedPasswordValid = (value: string) => {
    const isConfirmedPasswordValid = handlePasswordsEquality();
    setIsConfirmedPasswordValid(
      isConfirmedPasswordValid != null && isConfirmedPasswordValid
    );
    return isConfirmedPasswordValid;
  };
  return (
    <LabeledInput
      label={confirmedPasswordLabel}
      value={confirmedPassword}
      setValue={setConfirmedPassword}
      className={className}
      inputProps={{
        ...inputProps,
        isClearable: true,
        variant: "bordered",
        placeholder: "Confirm password *",
        type: "password",
        value: confirmedPassword,
        onBlur: () => {
          if (confirmedPassword.length < 6) return;
          if (handlePasswordsEquality) handlePasswordsEquality();
        },
      }}
      handleLabelProps={{
        setLabel: setConfirmedPasswordLabel,
        isInputValid: isConfirmedPasswordValid,
        successMessage: successMessage,
        errorMessage: errorMessage,
      }}
    />
  );
}
