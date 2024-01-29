import { UserDetails } from "@/types";
export interface RegisterRequest {
  email: string;
  username: string;
  password: string;
  avatar: string | undefined;
}

export enum RegisterUserResult {
  Created = "Created",
  InvalidUsername = "InvalidUsername",
  InvalidEmail = "InvalidEmail",
  InvalidAvatar = "InvalidAvatar",
  UsernameIsTaken = "UsernameIsTaken",
  EmailIsTaken = "EmailIsTaken",
}

export interface RegisterResponse {
  userCreationStatus: RegisterUserResult;
  user: UserDetails;
}
