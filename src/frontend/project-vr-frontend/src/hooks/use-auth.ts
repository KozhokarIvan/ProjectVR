import { User } from "@/types";
import { useAppSelector } from "./redux";
import { selectLoginInfo } from "@/redux/features/user/selector";
import { LoginInfo } from "@/redux/features/user";

export interface UseAuthData {
  user: User | null;
  logout: () => void;
  login: (username: string) => void;
}

export function useAuth(): LoginInfo {
  const user = useAppSelector(state => selectLoginInfo(state));
  return user;
}
