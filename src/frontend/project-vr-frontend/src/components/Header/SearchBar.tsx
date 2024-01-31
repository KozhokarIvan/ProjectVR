import { UsersContext } from "@/app/providers";
import { searchUsers } from "@/api/usersApi";
import { AuthUser } from "@/types";
import { Button, Input, NavbarContent } from "@nextui-org/react";
import Link from "next/link";
import { useContext, useState } from "react";

export interface SearchBarProps {
  loggedUser: AuthUser | null;
}

export default function SearchBar({ loggedUser }: SearchBarProps) {
  const [queryText, setQueryText] = useState<string>("");
  const { users, setUsers } = useContext(UsersContext);
  const onUsersSearch = async (searchText: string) => {
    if (searchText.length < 3) return;
    searchUsers(searchText, loggedUser?.userGuid)
      .then(users => setUsers(users))
      .catch(err => console.log("Error", err));
  };
  return (
    <NavbarContent>
      <Input
        variant="bordered"
        placeholder="Find a user..."
        color="primary"
        radius="none"
        size="sm"
        isClearable
        value={queryText}
        onChange={async (event: { target: { value: string } }) => {
          try {
            const newText = event.target.value;
            setQueryText(newText);
            await onUsersSearch(newText);
          } catch (err) {
            console.error("Error:", err);
          }
        }}
        onClear={async () => {
          try {
            setQueryText("");
          } catch (err) {
            console.error("Error:", err);
          }
        }}
      />
      <Link href="/random">
        <Button variant="ghost" color="primary">
          Random
        </Button>
      </Link>
    </NavbarContent>
  );
}
