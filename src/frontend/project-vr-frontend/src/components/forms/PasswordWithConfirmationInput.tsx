import { MutableRefObject, useState } from "react";
import ConfirmedPasswordInput from "./ConfirmPasswordInput";
import PasswordInput from "./PasswordInput";
import { useLabel } from "@/hooks/use-label";

export interface PasswordWithConfirmationProps {
  password: string;
  setPassword: (password: string) => void;
  setIsPasswordValid: (value: boolean) => void;
  setIsConfirmedPasswordValid: (value: boolean) => void;
  passwordClassName?: string;
  confirmPasswordClassName?: string;
}

export default function PasswordWithConfirmationInput({
  password,
  setPassword,
  setIsPasswordValid,
  setIsConfirmedPasswordValid,
  passwordClassName,
  confirmPasswordClassName,
}: PasswordWithConfirmationProps) {
  const [confirmedPassword, setConfirmedPassword] = useState("");
  const [confirmedPasswordLabel, setConfirmedPasswordLabel] = useLabel(
    "primary",
    ""
  );
  const handlePasswordsEquality = () => {
    if (password.length < 6) return null;
    return (
      password.length == confirmedPassword.length &&
      password == confirmedPassword
    );
  };
  return (
    <>
      <PasswordInput
        password={password}
        setPassword={setPassword}
        setIsPasswordValid={setIsPasswordValid}
        handlePasswordsEquality={handlePasswordsEquality}
        setConfirmedPasswordLabel={setConfirmedPasswordLabel}
        className={passwordClassName}
      />
      <ConfirmedPasswordInput
        confirmedPassword={confirmedPassword}
        setConfirmedPassword={setConfirmedPassword}
        setIsConfirmedPasswordValid={setIsConfirmedPasswordValid}
        handlePasswordsEquality={handlePasswordsEquality}
        confirmedPasswordLabel={confirmedPasswordLabel}
        setConfirmedPasswordLabel={setConfirmedPasswordLabel}
        className={confirmPasswordClassName}
      />
    </>
  );
}
