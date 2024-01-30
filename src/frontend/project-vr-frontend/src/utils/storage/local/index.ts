import {
  clearStorageItem,
  getStorageItem,
  setStorageItem,
} from "@/utils/storage";

export const getLocalStorageItem = <T>(key: string): T | null =>
  getStorageItem<T>(localStorage, key);

export const setLocalStorageItem = <T>(key: string, value: T): void =>
  setStorageItem<T>(localStorage, key, value);

export const clearLocalStorageItem = (key: string) =>
  clearStorageItem(localStorage, key);
