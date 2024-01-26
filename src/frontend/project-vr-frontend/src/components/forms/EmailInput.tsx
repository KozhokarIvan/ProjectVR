import { MutableRefObject, useState } from "react";
import LabeledInput from "./LabeledInput";
import { useLabel } from "@/hooks/use-label";

export interface EmailInputProps {
  email: string;
  setEmail: (email: string) => void;
  setIsEmailValid: (value: boolean) => void;
  className?: string;
}

export default function EmailInput({
  email,
  setEmail,
  setIsEmailValid,
  className,
}: EmailInputProps) {
  const [emailLabel, setEmailLabel] = useLabel("primary", "");
  const successMessage = "We promise to not spam !";
  const errorMessage = "*Wrong email";
  const isEmailValid = (value: string) => {
    const regex = /^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const isEmailValid = !!value.match(regex);
    setIsEmailValid(isEmailValid);
    return isEmailValid;
  };
  return (
    <LabeledInput
      label={emailLabel}
      value={email}
      setValue={setEmail}
      className={className}
      inputProps={{
        isClearable: true,
        placeholder: "Email *",
        value: email,
        onBlur: () => {
          if (email.length < 1) {
            setEmailLabel("primary", "");
            return;
          }
        },
      }}
      handleLabelProps={{
        setLabel: setEmailLabel,
        isInputValid: isEmailValid,
        successMessage: successMessage,
        errorMessage: errorMessage,
      }}
    />
  );
}
