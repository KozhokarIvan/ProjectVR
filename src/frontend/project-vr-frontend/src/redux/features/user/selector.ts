import { RootState } from "@/redux/store";

const selectAuthModule = (state: RootState) => state.auth;

export const selectLoginInfo = (state: RootState) => selectAuthModule(state);
