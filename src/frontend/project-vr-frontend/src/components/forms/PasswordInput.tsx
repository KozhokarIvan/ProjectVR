import { useLabel } from "@/hooks/use-label";
import { MutableRefObject, useState } from "react";
import LabeledInput from "./LabeledInput";
import { Color } from "@/types/nextui";

export interface PasswordInputProps {
  setIsPasswordValid: (value: boolean) => void;
  password: string;
  setPassword: (password: string) => void;
  handlePasswordsEquality?: () => boolean | null;
  setConfirmedPasswordLabel: (color: Color, message: string) => void;
  className?: string;
}

export default function PasswordInput({
  setIsPasswordValid,
  password,
  setPassword,
  handlePasswordsEquality,
  setConfirmedPasswordLabel,
  className,
}: PasswordInputProps) {
  const [passwordLabel, setPasswordLabel] = useLabel("primary", "");
  const successMessage = "Password meets the requirements";
  const longPasswordErrorMessage =
    "*Password must be longer than 6 symbols and contain only letters, numbers and the following characters '!', '#', '$', '%', '&', '?', '\"' ";
  const shortPasswordErrorMessage =
    "*Password length must be 6 or more characters";
  const [errorMessage, setErrorMessage] = useState(longPasswordErrorMessage);
  const isPasswordValid = (value: string) => {
    const regex = /^[A-Za-z\d!#$%&?"]{6,}$/;
    const isPasswordValid = !!value.match(regex);
    setIsPasswordValid(isPasswordValid);
    return isPasswordValid;
  };
  return (
    <LabeledInput
      label={passwordLabel}
      value={password}
      setValue={setPassword}
      className={className}
      inputProps={{
        isClearable: true,
        placeholder: "Password *",
        type: "password",
        value: password,
        onChange: event => {
          setPassword(event.target.value);
          setErrorMessage(shortPasswordErrorMessage);
          if (password.length < 6) return;
          setErrorMessage(longPasswordErrorMessage);
        },
        onClear: () => {
          setPassword("");
          if (passwordLabel.color != "success") return;
          setPasswordLabel("primary", "");
          setConfirmedPasswordLabel("primary", "");
        },
        onBlur: () => {
          if (password.length < 1) return;
          if (password.length < 6) return;
          if (!handlePasswordsEquality) return;
          const arePasswordsEqual = handlePasswordsEquality();
          if (arePasswordsEqual == null) return;
          if (!arePasswordsEqual)
            setConfirmedPasswordLabel("danger", "*Passwords don't match");
          else setConfirmedPasswordLabel("success", "Passwords match");
        },
      }}
      handleLabelProps={{
        setLabel: setPasswordLabel,
        isInputValid: isPasswordValid,
        successMessage,
        errorMessage,
      }}
    />
  );
}
