export const getCookie = (cookieKey: string): string | null => {
  if (typeof window === "undefined") {
    return null;
  }
  const name = cookieKey + "=";
  const decodedCookie = decodeURIComponent(document.cookie);
  const cookieArray = decodedCookie.split(";");

  for (let i = 0; i < cookieArray.length; i++) {
    let cookie = cookieArray[i].trim();

    if (cookie.indexOf(name) === 0) {
      return cookie.substring(name.length, cookie.length);
    }
  }

  return null;
};

export const setCookie = (cookieKey: string, cookieValue: string): void => {
  document.cookie = `${cookieKey}=${cookieValue}`;
};

export const getCookieOfType = <T>(cookieKey: string): T | null => {
  const cookieStringValue = getCookie(cookieKey);
  const userFromCookie = JSON.parse(cookieStringValue ?? "null") as T;
  return userFromCookie ? (userFromCookie as T) : null;
};

export const setCookieOfType = <T>(cookieKey: string, cookieValue: T): void => {
  const cookieValueStringified = JSON.stringify(cookieValue, null);
  setCookie(cookieKey, cookieValueStringified);
};
