import { User } from "@/types";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { getLocalStorageItem } from "@/utils/local-storage";
import { createSlice } from "@reduxjs/toolkit";

export interface LoginInfo {
  user: User | null;
}

const initialState: LoginInfo = {
  user: getLocalStorageItem(LOGGED_USER_STORAGE_KEY),
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
