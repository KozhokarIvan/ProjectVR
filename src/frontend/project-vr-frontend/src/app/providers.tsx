"use client";

import { UserSummary } from "@/types";
import { NextUIProvider } from "@nextui-org/react";
import { ThemeProvider as NextThemesProvider } from "next-themes";
import React, { useState } from "react";

export function Providers({ children }: { children: React.ReactNode }) {
  return (
    <NextUIProvider>
      <NextThemesProvider attribute="class" defaultTheme="dark">
        <UsersProvider>{children}</UsersProvider>
      </NextThemesProvider>
    </NextUIProvider>
  );
}

export interface IUsersContext {
  users: UserSummary[] | null;
  setUsers: (users: UserSummary[] | null) => void;
}
export const usersContextDefaultState = {
  users: null,
  setUsers: () => {},
};
export const UsersContext = React.createContext<IUsersContext>(
  usersContextDefaultState
);

const UsersProvider = ({ children }: { children: React.ReactNode }) => {
  const [users, setUsers] = useState<UserSummary[] | null>(null);
  return (
    <UsersContext.Provider
      value={{
        users: users,
        setUsers: users => {
          setUsers(users);
        },
      }}
    >
      {children}
    </UsersContext.Provider>
  );
};
