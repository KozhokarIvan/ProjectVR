"use client";
import { HttpStatusCode } from "@/api/HttpStatusCode";
import { RegisterUserResult } from "@/api/contracts/user/register";
import { createUser } from "@/api/usersApi";
import PasswordWithConfirmationInput from "@/components/forms/PasswordWithConfirmationInput";
import { useLabel } from "@/hooks/use-label";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { useLogin } from "@/hooks/use-login";
import { AuthUser } from "@/types";
import { Button, Divider, InputProps, Tooltip } from "@nextui-org/react";
import { redirect } from "next/navigation";
import { useState } from "react";

export interface EditPasswordSectionProps {
  className?: string;
}

export default function EditPasswordSection({
  className,
}: EditPasswordSectionProps) {
  const { user } = useLoggedUser();
  if (!user) redirect("/");
  const { loginAndRemember } = useLogin();
  const [avatar, setAvatar] = useState("");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [label, setLabel] = useLabel("primary", "");
  const [isEmailValid, setIsEmailValid] = useState(false);
  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const [isPasswordValid, setIsPasswordValid] = useState(false);
  const [isConfirmedPasswordValid, setIsConfirmedPasswordValid] =
    useState(false);
  const inputProps: InputProps = {
    size: "sm",
    radius: "none",
  };
  const handleRegister = async () => {
    setLabel("primary", "");
    try {
      const { statusCode, data: response } = await createUser({
        username: username,
        email: email,
        avatar: avatar,
        password: password,
      });
      let isUnknownerror = false;
      if (statusCode == HttpStatusCode.Ok) {
        if (response.userCreationStatus == RegisterUserResult.Created) {
          const user: AuthUser = {
            userGuid: response.user.guid,
            username: response.user.username,
            avatar: response.user.avatar,
          };
          loginAndRemember(user);
        } else isUnknownerror = true;
      } else if (statusCode == HttpStatusCode.BadRequest) {
        switch (response.userCreationStatus) {
          case RegisterUserResult.InvalidAvatar:
            setLabel("danger", "Invalid avatar link");
            break;
          case RegisterUserResult.InvalidEmail:
            setLabel("danger", "Invalid email");
            break;
          case RegisterUserResult.InvalidUsername:
            setLabel("danger", "Invalid username");
            break;
          default:
            isUnknownerror = true;
            break;
        }
      } else if (statusCode == HttpStatusCode.Conflict) {
        switch (response.userCreationStatus) {
          case RegisterUserResult.EmailIsTaken:
            setLabel("danger", `Email '${email}' is already used`);
            break;
          case RegisterUserResult.UsernameIsTaken:
            setLabel("danger", `Username '${username}' is already taken`);
            break;
          default:
            isUnknownerror = true;
            break;
        }
      } else isUnknownerror = true;
      if (isUnknownerror) setLabel("danger", "Unexpected server error");
    } catch (error) {
      setLabel("danger", "Can't reach server");
    }
  };
  return (
    <div className={`w-full ${className}`}>
      <div>
        <h2 className="text-3xl text-center mb-4">Password change</h2>
        <Divider />
        <p className={`text-${label.color} text-center`}>{label.message}</p>
        <PasswordWithConfirmationInput
          password={password}
          setPassword={setPassword}
          setIsPasswordValid={setIsPasswordValid}
          setIsConfirmedPasswordValid={setIsConfirmedPasswordValid}
          passwordClassName="mt-4"
          confirmPasswordClassName="mt-4"
          inputProps={inputProps}
        />
      </div>
      <div className="flex justify-end mt-4">
        <Tooltip
          content={`Check fields: ${!isUsernameValid ? "'username'" : ""} ${
            !isEmailValid ? "'email'" : ""
          } ${!isPasswordValid ? "'password'" : ""} ${
            !isConfirmedPasswordValid ? "'confirmed password'" : ""
          }`}
          isDisabled={
            isEmailValid &&
            isUsernameValid &&
            isPasswordValid &&
            isConfirmedPasswordValid
          }
        >
          <div>
            <Button variant="ghost" color="primary" onClick={async () => {}}>
              Change password
            </Button>
          </div>
        </Tooltip>
      </div>
    </div>
  );
}
