import { removeUser } from "@/redux/features/user";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { clearLocalStorageItem } from "@/utils/storage/local";
import { clearSessionStorageItem } from "@/utils/storage/session";
import { useCallback } from "react";
import { useAppDispatch } from "./redux";

export function useLogout(): () => void {
  const dispatch = useAppDispatch();
  const logout = useCallback(() => {
    clearSessionStorageItem(LOGGED_USER_STORAGE_KEY);
    clearLocalStorageItem(LOGGED_USER_STORAGE_KEY);
    dispatch(removeUser());
  }, []);
  return logout;
}
