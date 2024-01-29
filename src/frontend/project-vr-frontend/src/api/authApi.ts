import { HOST } from "./urls";
import { LOGIN_ROUTE } from "./routes";
import { Response } from "./contracts/response";
import { LoginRequest, LoginResponse } from "./contracts/user/login";
export const login = async (
  username: string
): Promise<Response<LoginResponse>> => {
  const url = HOST + LOGIN_ROUTE;
  const loginRequest: LoginRequest = {
    username: username,
  };
  try {
    const data = await fetch(url, {
      method: "post",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(loginRequest),
    });
    const result = await data.json();
    return {
      statusCode: data.status,
      message: data.statusText,
      data: result,
    };
  } catch (err) {
    console.error("Error: ", err);
    throw err;
  }
};
