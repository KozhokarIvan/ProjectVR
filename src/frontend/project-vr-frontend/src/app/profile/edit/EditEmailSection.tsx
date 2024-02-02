"use client";
import EmailInput from "@/components/forms/EmailInput";
import { useLabel } from "@/hooks/use-label";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { Button, Divider, InputProps, Tooltip } from "@nextui-org/react";
import { redirect } from "next/navigation";
import { useState } from "react";

export interface EditEmailSectionProps {
  className?: string;
}

export default function EditEmailSection({ className }: EditEmailSectionProps) {
  const { user } = useLoggedUser();
  if (!user) redirect("/");
  const [email, setEmail] = useState("");
  const [label, setLabel] = useLabel("primary", "");
  const [isEmailValid, setIsEmailValid] = useState(false);
  const inputProps: InputProps = {
    size: "sm",
    radius: "none",
  };
  return (
    <div className={`w-full ${className}`}>
      <div>
        <h2 className="text-3xl text-center mb-4">Email change</h2>
        <Divider />
        <p className={`text-${label.color} text-center`}>{label.message}</p>
        <EmailInput
          email={email}
          setEmail={setEmail}
          setIsEmailValid={setIsEmailValid}
          className="mt-4"
          inputProps={inputProps}
        />
      </div>
      <div className="flex justify-end mt-4">
        <Tooltip>
          <div>
            <Button variant="ghost" color="primary" onClick={async () => {}}>
              Change email
            </Button>
          </div>
        </Tooltip>
      </div>
    </div>
  );
}
