import { UserDetails, UserInfo } from "@/types";
import { HOST } from "./urls";
import { RANDOM_ROUTE, SEARCH_ROUTE, USERS_ROUTE } from "./routes";

export const searchUsers = async (
  query: string,
  loggedUserGuid: string | undefined
): Promise<UserInfo[]> => {
  const requestParameters = {
    method: "get",
    headers: new Headers({
      loggedUserGuid: loggedUserGuid ?? "",
    }),
  };
  const requestUrl =
    HOST + SEARCH_ROUTE + "?limit=100" + `${query && "&searchQuery=" + query}`;
  try {
    const response = await fetch(requestUrl, requestParameters);
    const users = await response.json();
    return users;
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const rollRandomUsers = async (
  loggedUserGuid: string | undefined
): Promise<UserInfo[]> => {
  const headers = new Headers();
  if (loggedUserGuid) headers.set("loggedUserGuid", loggedUserGuid);
  const requestParameters = {
    method: "get",
    headers: headers,
  };
  const requestUrl = HOST + RANDOM_ROUTE + "/100";
  try {
    const response = await fetch(requestUrl, requestParameters);
    const users: UserInfo[] = await response.json();
    return users;
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const getUser = async (
  username: string | undefined,
  loggedUserGuid: string | undefined
): Promise<UserDetails> => {
  const headers = new Headers();
  if (loggedUserGuid) headers.set("loggedUserGuid", loggedUserGuid);
  const requestParameters = {
    method: "get",
    headers: headers,
  };
  const requestUrl = HOST + USERS_ROUTE + `/${username}`;
  try {
    const response = await fetch(requestUrl, requestParameters);
    const user: UserDetails = await response.json();
    return user;
  } catch (err) {
    console.error(err);
    throw err;
  }
};
