export const getLocalStorageItem = <T>(key: string): T | null => {
  if (typeof window === "undefined") {
    return null;
  }
  const stringValue = localStorage.getItem(key);
  const userFromStorage = JSON.parse(stringValue ?? "null") as T;
  return userFromStorage ? (userFromStorage as T) : null;
};

export const setLocalStorageItem = <T>(key: string, value: T): void => {
  if (typeof window === "undefined") {
    return;
  }
  const valueStringified = JSON.stringify(value, null);
  localStorage.setItem(key, valueStringified);
};

export const clearLocalStorageItem = (key: string) =>
  localStorage.removeItem(key);
