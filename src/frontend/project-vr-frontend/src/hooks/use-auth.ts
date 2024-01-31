import { AuthUser } from "@/types";
import { useAppSelector } from "./redux";
import { selectLoginInfo } from "@/redux/features/user/selector";
import { LoginInfo, setUser } from "@/redux/features/user";
import { useEffect } from "react";
import { getLocalStorageItem } from "@/utils/storage/local";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { useDispatch } from "react-redux";
import { getSessionStorageItem } from "@/utils/storage/session";

export interface UseAuthData {
  user: AuthUser | null;
  logout: () => void;
  login: (user: AuthUser) => void;
}

export function useAuth(): LoginInfo {
  const loginInfo = useAppSelector(state => selectLoginInfo(state));
  const dispatch = useDispatch();
  useEffect(() => {
    if (!loginInfo.user) {
      const user =
        getLocalStorageItem<AuthUser>(LOGGED_USER_STORAGE_KEY) ??
        getSessionStorageItem<AuthUser>(LOGGED_USER_STORAGE_KEY);
      dispatch(setUser(user));
    }
  }, []);
  return loginInfo;
}
