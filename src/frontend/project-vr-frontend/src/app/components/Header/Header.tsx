import {
  Navbar,
  Link,
  Text,
  Input,
  Button,
  Switch,
  User,
  changeTheme,
  useTheme,
  Popover,
  Dropdown,
} from "@nextui-org/react";
import { FC, ReactElement, useState } from "react";
import { LoggedUser, UserInfo } from "@/app/pages/SearchUsers/SearchUsers";
import LoginModal from "../LoginModal/LoginModal";

export interface HeaderProps {
  setUsers: (users: UserInfo[]) => void;
  loggedUser: LoggedUser | null;
  setLoggedUser: (user: LoggedUser | null) => void;
}

export default function Header({
  setUsers,
  loggedUser,
  setLoggedUser,
}: HeaderProps) {
  const { type, isDark } = useTheme();

  const handleChange = () => {
    const nextTheme = isDark ? "light" : "dark";
    window.localStorage.setItem("data-theme", nextTheme);
    changeTheme(nextTheme);
  };

  const searchUsers = async (searchText: string) => {
    if (searchText.length < 3 && searchText.length > 0) {
      return;
    }
    const baseUrl = "https://localhost:8080/api/";
    const headers = loggedUser
      ? {
          loggedUserGuid: loggedUser.userGuid,
        }
      : undefined;
    const requestParameters = {
      method: "get",
      headers: headers,
    };

    const vrSetsRequest =
      baseUrl + `users${searchText ? `?vrset=${searchText}` : ""}`;
    const responseVrSets = await fetch(vrSetsRequest, requestParameters);
    const usersByVrSets = await responseVrSets.json();

    const gamesRequest =
      baseUrl + `users${searchText ? `?game=${searchText}` : ""}`;
    const responseGames = await fetch(gamesRequest, requestParameters);
    const usersByGames = await responseGames.json();

    const users = usersByGames.concat(usersByVrSets);

    setUsers(users);
  };

  const fetchRandomUsers = async () => {
    const request = "https://localhost:8080/api/users/random";
    const headers = loggedUser
      ? {
          loggedUserGuid: loggedUser.userGuid,
        }
      : undefined;
    const response = await fetch(request, {
      method: "get",
      headers: headers,
    });
    const users = await response.json();
    setUsers(users);
  };

  const [loginModalVisible, setLoginModalVIsible] = useState<boolean>(false);
  const openLoginModalHandler = () => setLoginModalVIsible(true);
  const closeLoginModalHandler = () => setLoginModalVIsible(false);
  return (
    <Navbar as="header" variant="sticky">
      <Navbar.Brand>
        <Link href="#">
          <Text h2 color="secondary">
            ProjectVR
          </Text>
        </Link>
      </Navbar.Brand>
      <Navbar.Content>
        <Input
          bordered
          placeholder="Find a user..."
          color="secondary"
          clearable
          onChange={async event => {
            await searchUsers(event.target.value);
          }}
        />
        <Button
          bordered
          color="secondary"
          auto
          onPress={async event => {
            await fetchRandomUsers();
          }}
        >
          Random
        </Button>
      </Navbar.Content>
      <Navbar.Content>
        <Switch color="secondary" checked={isDark} onChange={handleChange} />

        {loggedUser != null ? (
          <Dropdown>
            <Dropdown.Trigger>
              <User
                name={loggedUser.username}
                src={loggedUser.avatar}
                size="lg"
                zoomed
                pointer
              />
            </Dropdown.Trigger>
            <Dropdown.Menu
              color="secondary"
              variant="solid"
              onAction={key => {
                if (key.toString() == "logout") {
                  setLoggedUser(null);
                }
              }}
            >
              <Dropdown.Item key="profile">Profile</Dropdown.Item>
              <Dropdown.Item key="logout" color="error" withDivider>
                Log Out
              </Dropdown.Item>
            </Dropdown.Menu>
          </Dropdown>
        ) : (
          <Button
            auto
            color="secondary"
            bordered
            onPress={openLoginModalHandler}
          >
            Sign In
          </Button>
        )}
        <LoginModal
          visible={loginModalVisible}
          openHandler={openLoginModalHandler}
          closeHandler={closeLoginModalHandler}
          setLoggedUser={setLoggedUser}
        />
      </Navbar.Content>
    </Navbar>
  );
}
