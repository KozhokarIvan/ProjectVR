"use client";
import { useAppDispatch } from "@/hooks/redux";
import { useAuth } from "@/hooks/use-auth";
import { removeUser } from "@/redux/features/user";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { clearLocalStorageItem } from "@/utils/local-storage";
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
  const dispatch = useAppDispatch();
  const { user: loggedUser } = useAuth();
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
              dispatch(removeUser());
              clearLocalStorageItem(LOGGED_USER_STORAGE_KEY);
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
