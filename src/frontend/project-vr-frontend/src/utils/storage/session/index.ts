import {
  clearStorageItem,
  getStorageItem,
  setStorageItem,
} from "@/utils/storage";

export const getSessionStorageItem = <T>(key: string): T | null =>
  getStorageItem<T>(sessionStorage, key);

export const setSessionStorageItem = <T>(key: string, value: T): void =>
  setStorageItem(sessionStorage, key, value);

export const clearSessionStorageItem = (key: string) =>
  clearStorageItem(sessionStorage, key);
