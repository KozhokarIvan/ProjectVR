"use client";
import { useState, useEffect, useContext } from "react";
import { Spinner } from "@nextui-org/react";
import UsersSummary from "@/app/search/UsersSummary/UsersSummary";
import { User } from "@/types";
import { getCookieOfType } from "@/utils/cookies";
import { rollRandomUsers } from "@/http/usersApi";
import { UsersContext } from "../providers";

export default function Page() {
  const userFromCookie = getCookieOfType<User>("logged-user");
  const [loggedUser] = useState<User | null>(userFromCookie);

  const { users, setUsers } = useContext(UsersContext);

  useEffect(() => {
    rollRandomUsers(loggedUser?.userId)
      .then(users => setUsers(users))
      .catch(err => console.error(err));
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
        <Spinner label="Loading..." className="mt-32" />
      )}
    </main>
  );
}
