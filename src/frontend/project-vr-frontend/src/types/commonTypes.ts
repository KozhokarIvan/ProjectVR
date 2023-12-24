export interface UserSummary {
  avatar?: string;
  username: string;
  vrsets: VrSet[];
  games: Game[];
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
  games: Game[];
  vrSets: VrSet[];
}

export interface LoggedUser {
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

export interface Response<T> {
  statusCode: number;
  message: string;
  data: T;
}
