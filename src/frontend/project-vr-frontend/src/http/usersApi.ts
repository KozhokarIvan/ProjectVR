import { UserInfo } from "@/types/commonTypes";
import { HOST } from "./urls";
import { RANDOM_ROUTE, SEARCH_ROUTE } from "./routes";

export const searchUsers = async (
  query: string,
  loggedUserGuid: string | undefined
): Promise<UserInfo[]> => {
  const headers = new Headers();
  if (loggedUserGuid) headers.set("loggedUserGuid", loggedUserGuid.toString());
  const requestParameters = {
    method: "get",
    headers: headers,
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
  if (loggedUserGuid) headers.set("loggedUserGuid", loggedUserGuid.toString());
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
