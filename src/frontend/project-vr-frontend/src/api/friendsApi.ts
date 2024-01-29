import { HttpStatusCode } from "./HttpStatusCode";
import { FRIENDS_ROUTE, REQUESTS_ROUTE } from "./routes";
import { HOST } from "./urls";
import { Response as ApiResponse } from "@/api/contracts/response";

export const addFriend = async (
  loggedUserGuid: string,
  friendGuid: string
): Promise<ApiResponse<boolean>> => {
  const requestParameters = {
    method: "post",
    headers: new Headers({
      loggedUserGuid: loggedUserGuid,
    }),
  };
  const requestUrl = `${HOST}${FRIENDS_ROUTE}/${friendGuid}`;
  try {
    const data = await fetch(requestUrl, requestParameters);
    return {
      statusCode: data.status,
      message: data.statusText,
      data: data.status == HttpStatusCode.Ok,
    };
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const acceptFriend = async (
  loggedUserGuid: string,
  friendGuid: string
): Promise<ApiResponse<boolean>> => {
  const requestParameters = {
    method: "put",
    headers: new Headers({
      loggedUserGuid: loggedUserGuid,
    }),
  };
  const requestUrl = `${HOST}${REQUESTS_ROUTE}/${friendGuid}`;
  try {
    const data = await fetch(requestUrl, requestParameters);
    return {
      statusCode: data.status,
      message: data.statusText,
      data: data.status == HttpStatusCode.Ok,
    };
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const declineFriend = async (
  loggedUserGuid: string,
  friendGuid: string
): Promise<ApiResponse<boolean>> => {
  const requestParameters = {
    method: "delete",
    headers: new Headers({
      loggedUserGuid: loggedUserGuid,
    }),
  };
  const requestUrl = `${HOST}${REQUESTS_ROUTE}/${friendGuid}`;
  try {
    const data = await fetch(requestUrl, requestParameters);
    return {
      statusCode: data.status,
      message: data.statusText,
      data: data.status == HttpStatusCode.Ok,
    };
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const removeFriend = async (
  loggedUserGuid: string,
  friendGuid: string
): Promise<ApiResponse<boolean>> => {
  const requestParameters = {
    method: "delete",
    headers: new Headers({
      loggedUserGuid: loggedUserGuid,
    }),
  };
  const requestUrl = `${HOST}${FRIENDS_ROUTE}/${friendGuid}`;
  try {
    const data = await fetch(requestUrl, requestParameters);
    return {
      statusCode: data.status,
      message: data.statusText,
      data: data.status == HttpStatusCode.Ok,
    };
  } catch (err) {
    console.error(err);
    throw err;
  }
};
