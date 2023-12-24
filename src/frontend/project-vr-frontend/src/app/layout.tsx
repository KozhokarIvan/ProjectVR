"use client";
import "./globals.css";
import Header from "@/components/Header/Header";
import { useState } from "react";
import { Providers } from "./providers";
import { Inter } from "next/font/google";
import { LoggedUser, UserInfo } from "@/types/commonTypes";
import { getCookieOfType } from "@/utils/cookies";
import { LOGGED_USER_COOKIE_KEY } from "@/utils/consts";

const inter = Inter({ subsets: ["latin"] });

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const userFromCookie = getCookieOfType<LoggedUser>(LOGGED_USER_COOKIE_KEY);
  const [loggedUser, setLoggedUser] = useState<LoggedUser | null>(
    userFromCookie
  );
  return (
    <html lang="en">
      <body className={`${inter.className}`}>
        <Providers>
          <Header loggedUser={loggedUser} setLoggedUser={setLoggedUser} />
          {children}
        </Providers>
      </body>
    </html>
  );
}
