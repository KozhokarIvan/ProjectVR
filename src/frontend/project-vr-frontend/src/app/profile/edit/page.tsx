"use client";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { Button, ButtonProps } from "@nextui-org/react";
import { redirect } from "next/navigation";
import EditUserSection from "./EditUserSection";
import { useState } from "react";
import EditPasswordSection from "./EditPasswordSection";
import EditEmailSection from "./EditEmailSection";
import EditVrSetsSection from "./EditVrSetsSection";

enum TabState {
  Profile,
  Password,
  Email,
  VrSets,
  Games,
}

export default function EditPage() {
  const { user } = useLoggedUser();
  if (!user) redirect("/");
  const buttonProps: ButtonProps = {
    size: "lg",
    radius: "none",
    fullWidth: true,
    variant: "light",
  };
  const [tab, setTab] = useState<TabState>(TabState.Profile);
  const getButtonColor = (thisTab: TabState) =>
    tab == thisTab ? "primary" : buttonProps.color;
  return (
    <main className="px-[400px] pt-40">
      <div className="grid grid-cols-[300px_1fr]">
        <div>
          <Button
            {...buttonProps}
            color={getButtonColor(TabState.Profile)}
            onClick={() => setTab(TabState.Profile)}
          >
            Profile Info
          </Button>
          <Button
            {...buttonProps}
            color={getButtonColor(TabState.VrSets)}
            onClick={() => setTab(TabState.VrSets)}
          >
            My VrSets
          </Button>
          <Button
            {...buttonProps}
            color={getButtonColor(TabState.Games)}
            isDisabled
          >
            My Games
          </Button>
          <Button
            {...buttonProps}
            color={getButtonColor(TabState.Password)}
            onClick={() => setTab(TabState.Password)}
          >
            Password
          </Button>
          <Button
            {...buttonProps}
            color={getButtonColor(TabState.Email)}
            onClick={() => setTab(TabState.Email)}
          >
            Email
          </Button>
        </div>
        <div className="flex items-center justify-center ml-4">
          <EditUserSection
            className={tab == TabState.Profile ? "" : "hidden"}
          />
          <EditVrSetsSection
            className={tab == TabState.VrSets ? "" : "hidden"}
          />
          <EditPasswordSection
            className={tab == TabState.Password ? "" : "hidden"}
          />
          <EditEmailSection className={tab == TabState.Email ? "" : "hidden"} />
        </div>
      </div>
    </main>
  );
}
