"use client";
import AvatarUpload from "@/components/AvatarUpload";
import UsernameInput from "@/components/forms/UsernameInput";
import { useLabel } from "@/hooks/use-label";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { Button, Divider, InputProps, Tooltip } from "@nextui-org/react";
import { redirect } from "next/navigation";
import { useState } from "react";

export interface EditUserSectionProps {
  className?: string;
}

export default function EditUserSection({ className }: EditUserSectionProps) {
  const { user } = useLoggedUser();
  if (!user) redirect("/");
  const [avatar, setAvatar] = useState(user.avatar);
  const [username, setUsername] = useState(user.username);
  const [label, setLabel] = useLabel("primary", "");
  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const inputProps: InputProps = {
    size: "sm",
    radius: "none",
  };
  return (
    <div className={`w-full ${className}`}>
      <div>
        <h2 className="text-3xl text-center mb-4">Edit profile</h2>
        <Divider />
        <p className={`text-${label.color} text-center`}>{label.message}</p>
        <UsernameInput
          username={username}
          setUsername={setUsername}
          setIsUsernameValid={setIsUsernameValid}
          className="mt-4"
          inputProps={inputProps}
        />
        <div className="mt-4">
          <AvatarUpload
            avatar={avatar ?? ""}
            setAvatar={setAvatar}
            imgClassName="w-52"
            inputProps={inputProps}
          />
        </div>
      </div>
      <div className="flex justify-end mt-4">
        <Tooltip>
          <div>
            <Button variant="ghost" color="primary" onClick={() => {}}>
              Confirm
            </Button>
          </div>
        </Tooltip>
      </div>
    </div>
  );
}
