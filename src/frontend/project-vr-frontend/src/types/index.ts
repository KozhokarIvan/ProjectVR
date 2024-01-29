import { FriendStatus } from "./enums/FriendStatus";

export interface UserSummary {
  guid: string;
  username: string;
  avatar?: string;
  friendStatus: FriendStatus;
  vrSets: VrSet[];
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

export interface User {
  userGuid: string;
  username: string;
  avatar: string;
}
