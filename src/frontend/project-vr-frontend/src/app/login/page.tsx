"use client";
import { HttpStatusCode } from "@/api/HttpStatusCode";
import { login as apiLogin } from "@/api/authApi";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { useLogin } from "@/hooks/use-login";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Checkbox,
  Input,
  Link,
} from "@nextui-org/react";
import { redirect } from "next/navigation";
import React, { useState } from "react";

export default function LoginPage() {
  const { user } = useLoggedUser();
  if (user) redirect("/");
  const { login, loginAndRemember } = useLogin();
  const [isRememberMe, setIsRememberMe] = useState(false);

  const [enteredLogin, setEnteredLogin] = useState("");
  const [enteredPassword, setEnteredPassword] = useState("");
  const [loginLabelColor, setLoginLabelColor] = useState<"primary" | "danger">(
    "primary"
  );
  const [loginErrorMessage, setLoginErrorMessage] = useState("");
  const handleLogin = async (username: string) => {
    try {
      const { statusCode, data: user } = await apiLogin(username);
      if (statusCode == HttpStatusCode.NotFound) {
        setLoginErrorMessage("User doesnt exist");
        setLoginLabelColor("danger");
        return;
      }
      if (isRememberMe) {
        loginAndRemember(user);
      } else {
        login(user);
      }
      setLoginLabelColor("primary");
      setLoginErrorMessage("");
      setEnteredLogin("");
      setEnteredPassword("");
    } catch (error) {
      setLoginErrorMessage("Unknown error");
      setLoginLabelColor("danger");
    }
  };
  return (
    <main className="flex items-center justify-center">
      <Card
        className="mt-32 w-2/5 bg-transparent border-1 border-default-100 p-5"
        radius="none"
      >
        <CardBody>
          <h2 className="text-3xl text-center mb-4">Login</h2>
          <Input
            isClearable
            variant="bordered"
            fullWidth
            color={loginLabelColor}
            label={loginErrorMessage}
            size="md"
            placeholder="Username"
            value={enteredLogin}
            onChange={event => {
              setEnteredLogin(event.target.value);
            }}
            onClear={() => setEnteredLogin("")}
          />
          <Input
            className="mt-4"
            isClearable
            variant="bordered"
            fullWidth
            color="primary"
            size="md"
            placeholder="Password"
            type="password"
            value={enteredPassword}
            onChange={event => {
              setEnteredPassword(event.target.value);
            }}
            onClear={() => {
              setEnteredPassword("");
            }}
          />
          <Checkbox
            className="mt-1"
            defaultChecked={isRememberMe}
            onValueChange={setIsRememberMe}
          >
            <p>Remember me</p>
          </Checkbox>
        </CardBody>
        <CardFooter className="flex justify-between">
          <Link color="primary" href="/register">
            Don't have an account ?
          </Link>
          <Button
            variant="ghost"
            color="primary"
            onPress={() => handleLogin(enteredLogin)}
          >
            Sign in
          </Button>
        </CardFooter>
      </Card>
    </main>
  );
}
