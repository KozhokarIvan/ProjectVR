"use client";
import {
  Navbar,
  Button,
  Switch,
  User,
  Dropdown,
  DropdownMenu,
  DropdownTrigger,
  DropdownItem,
  NavbarBrand,
  NavbarContent,
  useDisclosure,
} from "@nextui-org/react";
import { useState } from "react";
import LoginModal from "../LoginModal/LoginModal";
import SearchBar from "./SearchBar";
import Link from "next/link";
import { useTheme } from "next-themes";
import { useAuth } from "@/hooks/use-auth";
import { removeUser } from "@/redux/features/user";
import { useAppDispatch } from "@/hooks/redux";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { clearLocalStorageItem } from "@/utils/local-storage";

export default function Header() {
  const { isOpen, onOpen, onOpenChange } = useDisclosure();
  const [isDark, setIsDark] = useState<boolean>(true);
  const { setTheme } = useTheme();
  const dispatch = useAppDispatch();
  const { user: loggedUser } = useAuth();
  const handleChange = () => {
    if (isDark) {
      setTheme("light");
      setIsDark(false);
    } else {
      setTheme("dark");
      setIsDark(true);
    }
  };
  return (
    <Navbar as="header" position="sticky">
      <NavbarBrand>
        <Link href="/">
          <h2 className="text-secondary text-3xl font-bold">ProjectVR</h2>
        </Link>
      </NavbarBrand>
      <SearchBar loggedUser={loggedUser} />
      <NavbarContent>
        <Switch color="secondary" checked={isDark} onChange={handleChange} />

        {loggedUser != null ? (
          <Dropdown>
            <DropdownTrigger>
              <User
                name={loggedUser.username}
                avatarProps={{
                  src: loggedUser.userAvatar,
                  showFallback: true,
                  name: undefined,
                  radius: "lg",
                }}
                className=" hover:cursor-pointer"
              />
            </DropdownTrigger>
            <DropdownMenu
              color="secondary"
              variant="solid"
              onAction={(key: { toString: () => string }) => {
                if (key.toString() == "logout") {
                  dispatch(removeUser());
                  clearLocalStorageItem(LOGGED_USER_STORAGE_KEY);
                }
              }}
            >
              <DropdownItem key="profile">Profile</DropdownItem>
              <DropdownItem key="logout" color="danger">
                Log Out
              </DropdownItem>
            </DropdownMenu>
          </Dropdown>
        ) : (
          <Button variant="ghost" color="secondary" onPress={onOpen}>
            Sign In
          </Button>
        )}
        <LoginModal isOpen={isOpen} onOpenChange={onOpenChange} />
      </NavbarContent>
    </Navbar>
  );
}
