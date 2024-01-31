"use client";
import { HttpStatusCode } from "@/api/HttpStatusCode";
import { RegisterUserResult } from "@/api/contracts/user/register";
import { createUser } from "@/api/usersApi";
import EmailInput from "@/components/forms/EmailInput";
import PasswordWithConfirmationInput from "@/components/forms/PasswordWithConfirmationInput";
import UsernameInput from "@/components/forms/UsernameInput";
import { useLabel } from "@/hooks/use-label";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { useLogin } from "@/hooks/use-login";
import { AuthUser } from "@/types";
import { Button, Card, CardBody, CardFooter, Tooltip } from "@nextui-org/react";
import { redirect } from "next/navigation";
import { useState } from "react";
import AvatarUpload from "./AvatarUpload";
export default function RegisterPage() {
  const { user } = useLoggedUser();
  if (user) redirect("/");
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
  const handleRegister = async () => {
    setLabel("primary", "");
    try {
      const {
        statusCode,
        message,
        data: response,
      } = await createUser({
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
    <main className="flex items-center justify-center">
      <Card
        className="mt-24 w-2/5 bg-transparent border-1 border-default-100 p-5"
        radius="none"
      >
        <CardBody>
          <h2 className="text-3xl text-center mb-4">Register</h2>
          <p className={`text-${label.color} text-center`}>{label.message}</p>
          <EmailInput
            email={email}
            setEmail={setEmail}
            setIsEmailValid={setIsEmailValid}
            className="mt-4"
          />
          <UsernameInput
            username={username}
            setUsername={setUsername}
            setIsUsernameValid={setIsUsernameValid}
            className="mt-4"
          />
          <div className="mt-4">
            <AvatarUpload
              avatar={avatar}
              setAvatar={setAvatar}
              imgClassName="w-52"
            />
          </div>
          <PasswordWithConfirmationInput
            password={password}
            setPassword={setPassword}
            setIsPasswordValid={setIsPasswordValid}
            setIsConfirmedPasswordValid={setIsConfirmedPasswordValid}
            passwordClassName="mt-4"
            confirmPasswordClassName="mt-4"
          />
        </CardBody>
        <CardFooter className="flex justify-end">
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
              <Button
                variant="ghost"
                color="primary"
                onClick={async () => {
                  handleRegister();
                }}
                isDisabled={
                  !(
                    isEmailValid &&
                    isUsernameValid &&
                    isPasswordValid &&
                    isConfirmedPasswordValid
                  )
                }
              >
                Register
              </Button>
            </div>
          </Tooltip>
        </CardFooter>
      </Card>
    </main>
  );
}
