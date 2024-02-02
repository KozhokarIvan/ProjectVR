import { MutableRefObject, useState } from "react";
import LabeledInput from "./LabeledInput";
import { useLabel } from "@/hooks/use-label";
import { InputProps } from "@nextui-org/react";

export interface UsernameInputProps {
  username: string;
  setUsername: (username: string) => void;
  setIsUsernameValid: (value: boolean) => void;
  className?: string;
  inputProps?: InputProps;
}

export default function UsernameInput({
  username,
  setUsername,
  setIsUsernameValid,
  className,
  inputProps,
}: UsernameInputProps) {
  const successMessage = "Cool username !";
  const errorMessage =
    "*Username must be longer than 6 symbols and contain only letters, numbers and the following characters '.', '_', '-'";
  const [usernameLabel, setUsernameLabel] = useLabel("primary", "");
  const isUsernameValid = (value: string) => {
    const regex = /^[a-zA-Z0-9_\-.]{6,}$/;
    const isUsernameValid = !!value.match(regex);
    setIsUsernameValid(isUsernameValid);
    return isUsernameValid;
  };
  return (
    <LabeledInput
      label={usernameLabel}
      value={username}
      setValue={setUsername}
      className={className}
      inputProps={{
        ...inputProps,
        isClearable: true,
        placeholder: "Username *",
        value: username,
        onChange: event => {
          setUsername(event.target.value);
          if (username.length < 1) return;
          if (username.length < 6) return;
        },
        onBlur: () => {
          if (username.length < 1) return;
          if (username.length < 6) {
            setUsernameLabel(
              "danger",
              "Username must be longer than 6 characters"
            );
            return;
          }
        },
      }}
      handleLabelProps={{
        setLabel: setUsernameLabel,
        isInputValid: isUsernameValid,
        successMessage,
        errorMessage,
      }}
    />
  );
}
