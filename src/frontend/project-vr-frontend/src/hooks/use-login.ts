import { setUser } from "@/redux/features/user";
import { AuthUser } from "@/types";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { setLocalStorageItem } from "@/utils/storage/local";
import { setSessionStorageItem } from "@/utils/storage/session";
import { useCallback } from "react";
import { useAppDispatch } from "./redux";

export interface UseLoginData {
  login: (user: AuthUser) => void;
  loginAndRemember: (user: AuthUser) => void;
}

export function useLogin(): UseLoginData {
  const dispatch = useAppDispatch();
  const login = useCallback((user: AuthUser) => {
    setSessionStorageItem(LOGGED_USER_STORAGE_KEY, user);
    dispatch(setUser(user));
  }, []);
  const loginAndRemember = useCallback((user: AuthUser) => {
    setLocalStorageItem(LOGGED_USER_STORAGE_KEY, user);
    dispatch(setUser(user));
  }, []);
  const useLoginData: UseLoginData = {
    login: login,
    loginAndRemember: loginAndRemember,
  };
  return useLoginData;
}
