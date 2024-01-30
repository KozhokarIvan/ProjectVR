export const getStorageItem = <T>(storage: Storage, key: string): T | null => {
  if (typeof window === "undefined") {
    return null;
  }
  const stringValue = storage.getItem(key);
  const valueFromStorage: T = JSON.parse(stringValue ?? "null") as T;
  return valueFromStorage ? valueFromStorage : null;
};

export const setStorageItem = <T>(
  storage: Storage,
  key: string,
  value: T
): void => {
  if (typeof window === "undefined") {
    return;
  }
  const valueStringified = JSON.stringify(value, null);
  storage.setItem(key, valueStringified);
};

export const clearStorageItem = (storage: Storage, key: string) =>
  storage.removeItem(key);
