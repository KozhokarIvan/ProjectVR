import { FriendStatus } from "./enums/FriendStatus";

export interface UserSummary {
  guid: string;
  username: string;
  avatar?: string;
  friendStatus: FriendStatus;
  vrSets: UserVrSet[];
  games: UserGame[];
}

export interface UserDetails {
  guid: string;
  avatar?: string;
  username: string;
  friendStatus: FriendStatus;
  createdAt: Date;
  vrSets: UserVrSet[];
  games: UserGame[];
  friends: FriendInfo[];
}

export interface FriendInfo {
  username: string;
  avatar?: string;
}

export interface UserGame {
  gameId: number;
  gameName: string;
  isFavorite: boolean;
  rating?: number;
  gameIcon?: string;
}

export interface UserVrSet {
  vrSetId: number;
  vrSetName: string;
  isFavorite: boolean;
  vrSetIcon?: string;
}

export interface AuthUser {
  userGuid: string;
  username: string;
  avatar?: string;
}
export interface VrSet {
  id: number;
  name: string;
  icon?: string;
}
