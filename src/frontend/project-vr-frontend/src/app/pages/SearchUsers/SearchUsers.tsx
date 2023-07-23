import { useState, useEffect } from "react";
import { Spacer, Container, Text } from "@nextui-org/react";
import Header from "@/app/components/Header/Header";
import UsersSummary from "@/app/pages/SearchUsers/UsersSummary/UsersSummary";

export interface Game {
  gameId: number;
  name: string;
  isFavorite: boolean;
  rating?: number;
  icon?: string;
}

export interface VrSet {
  vrSetId: number;
  name: string;
  isFavorite: boolean;
  icon?: string;
}

export interface UserInfo {
  guid: string;
  username: string;
  avatar?: string;
  games: Game[];
  vrSets: VrSet[];
}

export interface LoggedUser {
  userGuid: string;
  username: string;
  avatar: string;
}

function getCookie(cookieName: string): string | null {
  if (typeof window === "undefined") {
    return null;
  }
  const name = cookieName + "=";
  const decodedCookie = decodeURIComponent(document.cookie);
  const cookieArray = decodedCookie.split(";");

  for (let i = 0; i < cookieArray.length; i++) {
    let cookie = cookieArray[i].trim();

    if (cookie.indexOf(name) === 0) {
      return cookie.substring(name.length, cookie.length);
    }
  }

  return null;
}

export default function SearchUsers() {
  const [users, setUsers] = useState<UserInfo[]>([]);
  const cookieStringValue = getCookie("logged-user");
  const userFromCookie = JSON.parse(cookieStringValue ?? "null") as LoggedUser;
  const [loggedUser, setLoggedUser] = useState<LoggedUser | null>(
    userFromCookie
  );
  useEffect(() => {
    const fetchUsers = async () => {
      const data = await fetch("https://localhost:8080/api/users", {
        method: "get",
      });

      const users = await data.json();
      setUsers(users);
    };

    fetchUsers().catch(err => console.log("Error: ", err));
  }, []);

  return (
    <main>
      <Header
        setUsers={setUsers}
        loggedUser={loggedUser}
        setLoggedUser={setLoggedUser}
      />
      <Spacer y={3} />
      {users && users.length > 0 ? (
        <UsersSummary users={users} />
      ) : (
        <Container justify="center">
          <Text h2>No users found</Text>
        </Container>
      )}
    </main>
  );
}
