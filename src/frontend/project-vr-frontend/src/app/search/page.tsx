"use client";
import { useEffect, useContext } from "react";
import { Spinner } from "@nextui-org/react";
import UsersSummary from "@/app/search/UsersSummary";
import { rollRandomUsers } from "@/api/usersApi";
import { UsersContext } from "../providers";
import { useLoggedUser } from "@/hooks/use-logged-user";

export default function Page() {
  const { user: loggedUser } = useLoggedUser();
  const { users, setUsers } = useContext(UsersContext);
  useEffect(() => {
    rollRandomUsers(loggedUser?.userGuid)
      .then(fetchedUsers => {
        setUsers(fetchedUsers);
      })
      .catch(err => console.error("Error:", err));
    return setUsers([]);
  }, [loggedUser]);
  return (
    <main className="grid items-center justify-center mt-16">
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
