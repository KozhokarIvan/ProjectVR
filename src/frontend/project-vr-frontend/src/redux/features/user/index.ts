import { AuthUser } from "@/types";
import { createSlice } from "@reduxjs/toolkit";

export interface LoginInfo {
  user: AuthUser | null;
}

const initialState: LoginInfo = {
  user: null,
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    setUser: (state, { payload }) => {
      if (!payload) return;
      state.user = payload;
    },
    removeUser: state => {
      state.user = null;
    },
  },
});

export const authReducer = authSlice.reducer;
export const { setUser, removeUser } = authSlice.actions;
