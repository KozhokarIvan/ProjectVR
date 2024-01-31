"use client";
import { useAppDispatch } from "@/hooks/redux";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { useLogout } from "@/hooks/use-logout";
import { removeUser } from "@/redux/features/user";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { clearLocalStorageItem } from "@/utils/storage/local";
import { clearSessionStorageItem } from "@/utils/storage/session";
import {
  Button,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownTrigger,
  Link,
  User,
} from "@nextui-org/react";

export default function Profile() {
  const logout = useLogout();
  const { user: loggedUser } = useLoggedUser();
  if (!loggedUser)
    return (
      <Link href="/login">
        <Button variant="ghost" color="primary">
          Sign In
        </Button>
      </Link>
    );
  return (
    <Dropdown>
      <DropdownTrigger>
        <User
          name={loggedUser.username}
          avatarProps={{
            src: loggedUser.avatar,
            showFallback: true,
            name: undefined,
            radius: "lg",
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
        <DropdownItem key="profile" href={`/users/${loggedUser.username}`}>
          <p>Profile</p>
        </DropdownItem>
        <DropdownItem key="logout" color="danger">
          Log Out
        </DropdownItem>
      </DropdownMenu>
    </Dropdown>
  );
}
