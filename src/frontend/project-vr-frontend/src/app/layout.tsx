import "./globals.css";
import Header from "@/components/Header";
import React, { useState } from "react";
import { Providers } from "./providers";
import { Inter } from "next/font/google";
import { StoreProvider } from "@/redux/StoreProvider";

const inter = Inter({ subsets: ["latin"] });

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className={`${inter.className}`}>
        <Providers>
          <StoreProvider>
            <Header />
            {children}
          </StoreProvider>
        </Providers>
      </body>
    </html>
  );
}
