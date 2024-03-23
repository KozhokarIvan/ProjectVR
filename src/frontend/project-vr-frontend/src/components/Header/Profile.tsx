"use client";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { useLogout } from "@/hooks/use-logout";
import {
  Button,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownTrigger,
  Link,
  Skeleton,
  User,
} from "@nextui-org/react";

export default function Profile() {
  const logout = useLogout();
  const { user: loggedUser, isDone } = useLoggedUser();
  if (isDone && !loggedUser)
    return (
      <Link href="/login">
        <Button radius="none" variant="ghost" color="primary">
          Sign In
        </Button>
      </Link>
    );
  return (
    <Dropdown>
      <DropdownTrigger>
        <User
          name={isDone && loggedUser ? loggedUser.username : ""}
          avatarProps={{
            isBordered: true,
            showFallback: true,
            src: isDone && loggedUser ? loggedUser.avatar : "",
            name: " ",
            radius: "none",
          }}
          className=" hover:cursor-pointer"
        />
      </DropdownTrigger>
      <DropdownMenu
        color="primary"
        variant="solid"
        onAction={(key: { toString: () => string }) => {
          const choice = key.toString();
          switch (choice) {
            case "logout":
              logout();
              break;
          }
        }}
      >
        <DropdownItem key="profile" href={`/profile`}>
          <p>Profile</p>
        </DropdownItem>
        <DropdownItem key="logout" color="danger">
          Log Out
        </DropdownItem>
      </DropdownMenu>
    </Dropdown>
  );
}
