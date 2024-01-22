"use client";
import { Navbar, Switch, NavbarBrand, NavbarContent } from "@nextui-org/react";
import { useState } from "react";
import SearchBar from "./SearchBar";
import Link from "next/link";
import { useTheme } from "next-themes";
import { useAuth } from "@/hooks/use-auth";
import Profile from "./Profile";

export default function Header() {
  const [isDark, setIsDark] = useState<boolean>(true);
  const { setTheme } = useTheme();
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
    <Navbar
      as="header"
      position="sticky"
      className="border-b border-b-default-100"
    >
      <NavbarBrand>
        <Link href="/">
          <h2 className="text-primary text-3xl font-bold">ProjectVR</h2>
        </Link>
      </NavbarBrand>
      <SearchBar loggedUser={loggedUser} />
      <NavbarContent>
        <Switch color="primary" checked={isDark} onChange={handleChange} />
        <Profile />
      </NavbarContent>
    </Navbar>
  );
}
