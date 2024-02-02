import { setUser } from "@/redux/features/user";
import { selectLoginInfo } from "@/redux/features/user/selector";
import { AuthUser } from "@/types";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { getLocalStorageItem } from "@/utils/storage/local";
import { getSessionStorageItem } from "@/utils/storage/session";
import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "./redux";

export interface UseLoggedUserData {
  user: AuthUser | null;
  isDone: boolean;
}

export function useLoggedUser(): UseLoggedUserData {
  const loginInfo = useAppSelector(state => selectLoginInfo(state));
  const dispatch = useAppDispatch();
  const [isDone, setIsDone] = useState(false);
  useEffect(() => {
    if (!loginInfo.user) {
      const user =
        getLocalStorageItem<AuthUser>(LOGGED_USER_STORAGE_KEY) ??
        getSessionStorageItem<AuthUser>(LOGGED_USER_STORAGE_KEY);
      dispatch(setUser(user));
    }
    setIsDone(true);
  }, []);
  return { user: loginInfo.user, isDone: isDone };
}
