"use client";
import { useEffect, useContext } from "react";
import { Spinner } from "@nextui-org/react";
import UsersSummary from "@/app/search/UsersSummary/UsersSummary";
import { rollRandomUsers } from "@/http/usersApi";
import { UsersContext } from "../providers";
import { useAuth } from "@/hooks/use-auth";

export default function Page() {
  const { user: loggedUser } = useAuth();
  const { users, setUsers } = useContext(UsersContext);
  useEffect(() => {
    rollRandomUsers(loggedUser?.userId)
      .then(fetchedUsers => {
        setUsers(fetchedUsers);
      })
      .catch(err => console.error("Error:", err));
  }, [loggedUser]);
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
