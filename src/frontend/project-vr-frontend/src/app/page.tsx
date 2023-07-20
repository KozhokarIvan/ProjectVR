"use client";
import { NextUIProvider } from "@nextui-org/react";
import { createTheme } from "@nextui-org/react";
import { useState, useEffect } from "react";
import { getDocumentTheme } from "@nextui-org/react";
import SearchUsers from "@/app/pages/SearchUsers/SearchUsers";

export default function Home() {
  const darkTheme = createTheme({
    type: "dark",
  });

  const lightTheme = createTheme({
    type: "light",
  });

  const [isDark, setDark] = useState<boolean>(true);

  useEffect(() => {
    let theme = window.localStorage.getItem("data-theme");
    setDark(theme === "dark");
    const observer = new MutationObserver(mutation => {
      let newTheme = getDocumentTheme(document?.documentElement);
      setDark(newTheme === "dark");
    });

    observer.observe(document?.documentElement, {
      attributes: true,
      attributeFilter: ["data-theme", "style"],
    });
    return () => observer.disconnect();
  }, []);

  return (
    <NextUIProvider theme={isDark ? darkTheme : lightTheme}>
      <SearchUsers />
    </NextUIProvider>
  );
}
