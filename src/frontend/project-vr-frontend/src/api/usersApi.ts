import { UserDetails, UserSummary, UserVrSet } from "@/types";
import { HOST } from "./urls";
import {
  RANDOM_ROUTE,
  SEARCH_ROUTE,
  USERS_ROUTE,
  USER_VRSETS_ROUTE,
} from "./routes";
import { RegisterRequest, RegisterResponse } from "./contracts/user/register";
import { Response } from "@/api/contracts/response";
export const searchUsers = async (
  query: string,
  loggedUserGuid: string | undefined
): Promise<UserSummary[]> => {
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
    const users: UserSummary[] = await response.json();
    return users;
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const rollRandomUsers = async (
  loggedUserGuid: string | undefined
): Promise<UserSummary[]> => {
  const headers = new Headers();
  if (loggedUserGuid) headers.set("loggedUserGuid", loggedUserGuid);
  const requestParameters = {
    method: "get",
    headers: headers,
  };
  const requestUrl = HOST + RANDOM_ROUTE + "/100";
  try {
    const response = await fetch(requestUrl, requestParameters);
    const users: UserSummary[] = await response.json();
    return users;
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const getUser = async (
  username: string,
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

export const createUser = async (
  user: RegisterRequest
): Promise<Response<RegisterResponse>> => {
  const headers = new Headers({ "Content-Type": "application/json;" });
  const requestParameters = {
    method: "post",
    headers: headers,
    body: JSON.stringify(
      {
        username: user.username,
        email: user.email,
        avatar: user.avatar,
        password: user.password,
      },
      null
    ),
  };
  const requestUrl = HOST + USERS_ROUTE;
  try {
    const response = await fetch(requestUrl, requestParameters);
    const data = await response.json();
    return {
      statusCode: response.status,
      message: response.statusText,
      data: data,
    };
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const getUserVrSets = async (
  loggedUserGuid: string,
  limit: number,
  offset?: number
): Promise<UserVrSet[]> => {
  const headers = new Headers({ loggedUserGuid: loggedUserGuid });
  const requestParameters = {
    method: "get",
    headers: headers,
  };
  const requestUrl =
    HOST + USER_VRSETS_ROUTE + `?limit=${limit}&offset=${offset}`;
  try {
    const response = await fetch(requestUrl, requestParameters);
    const vrSets: UserVrSet[] = await response.json();
    return vrSets;
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const setUserVrSets = async (
  loggedUserGuid: string,
  vrSets: UserVrSet[]
): Promise<globalThis.Response> => {
  const headers = new Headers({
    loggedUserGuid: loggedUserGuid,
    "Content-Type": "application/json;",
  });
  const requestParameters = {
    method: "put",
    headers: headers,
    body: JSON.stringify(
      {
        vrSets: vrSets.map(vs => {
          return {
            vrSetId: vs.vrSetId,
            isFavorite: vs.isFavorite,
          };
        }),
      },
      null
    ),
  };
  const requestUrl = HOST + USER_VRSETS_ROUTE;
  try {
    const response = await fetch(requestUrl, requestParameters);
    return response;
  } catch (err) {
    console.error(err);
    throw err;
  }
};
