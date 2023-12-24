"use client";
import { useState, useEffect, useContext } from "react";
import { Spinner } from "@nextui-org/react";
import UsersSummary from "@/app/search/UsersSummary/UsersSummary";
import { rollRandomUsers, searchUsers } from "@/http/usersApi";
import { getCookieOfType } from "@/utils/cookies";
import { LoggedUser, UserInfo } from "@/types/commonTypes";
import { UsersContext } from "../providers";

export interface PageProps {
  loggedUser: LoggedUser;
  users: UserInfo[];
  setUsers: (users: UserInfo[]) => void;
}

export default function Page() {
  const userFromCookie = getCookieOfType<LoggedUser>("logged-user");
  const [loggedUser, setLoggedUser] = useState<LoggedUser | null>(
    userFromCookie
  );
  const { users, setUsers } = useContext(UsersContext);
  useEffect(() => {
    rollRandomUsers(loggedUser?.userGuid)
      .then(fetchedUsers => {
        setUsers(fetchedUsers);
      })
      .catch(err => console.error("Error:", err));
  }, []);
  return (
    <main className="grid items-center justify-center">
      {users ? (
        users.length > 0 ? (
          <UsersSummary users={users} />
        ) : (
          <h2 className="mt-32 text-4xl">No users found</h2>
        )
      ) : (
        <Spinner
          classNames={{
            label: "text-3xl font-bold bg-white",
          }}
          label="Loading..."
          className="mt-32"
        />
      )}
    </main>
  );
}
