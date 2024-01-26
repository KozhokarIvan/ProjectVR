import { FriendStatus } from "./enums/FriendStatus";

export interface UserSummary {
  avatar?: string;
  username: string;
  friendStatus: FriendStatus;
  vrsets: VrSet[];
  games: Game[];
}

export interface UserDetails {
  guid: string;
  avatar?: string;
  username: string;
  friendStatus: FriendStatus;
  createdAt: Date;
  vrSets: VrSet[];
  games: Game[];
  friends: FriendInfo[];
}

export interface FriendInfo {
  username: string;
  avatar?: string;
}

export interface Game {
  gameId: number;
  gameName: string;
  isFavorite: boolean;
  rating?: number;
  gameIcon?: string;
}

export interface VrSet {
  vrSetId: number;
  vrSetName: string;
  isFavorite: boolean;
  vrSetIcon?: string;
}

export interface UserInfo {
  guid: string;
  username: string;
  avatar?: string;
  friendStatus: FriendStatus;
  games: Game[];
  vrSets: VrSet[];
}

export interface User {
  userGuid: string;
  username: string;
  avatar: string;
}

export interface LoginResponse {
  userGuid: string;
  username: string;
  avatar: string;
}

export interface LoginRequest {
  username: string;
}

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
  result: RegisterUserResult;
  user: UserDetails;
}

export interface Response<T> {
  statusCode: number;
  message: string;
  data: T;
}
