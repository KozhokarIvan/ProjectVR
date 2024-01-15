"use client";

import { store } from "@/redux/store";
import React, { ReactNode } from "react";
import { Provider } from "react-redux";

export const StoreProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  return <Provider store={store}>{children}</Provider>;
};
