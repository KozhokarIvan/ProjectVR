import { UserVrSet } from "@/types";
import {
  Dispatch,
  MutableRefObject,
  SetStateAction,
  useEffect,
  useRef,
  useState,
} from "react";
import { useLoggedUser } from "./use-logged-user";
import { redirect } from "next/navigation";
import { getUserVrSets } from "@/api/usersApi";
import { setUserVrSets as requestSetUserVrSets } from "@/api/usersApi";

export interface UseFetchUserVrSetsResult {
  isUserVrSetsLoaded: boolean;
  initialUserVrSets: MutableRefObject<UserVrSet[]>;
  userVrSets: UserVrSet[];
  setUserVrSets: Dispatch<SetStateAction<UserVrSet[]>>;
  requestSaveUserVrSets: () => void;
}

export function useFetchUserVrSets() {
  const { user } = useLoggedUser();

  const [isUserVrSetsLoaded, setIsUserVrSetsLoaded] = useState<boolean>(false);
  const initialUserVrSets = useRef<UserVrSet[]>([]);
  const [userVrSets, setUserVrSets] = useState<UserVrSet[]>([]);

  const applyFetchedUserVrSets = (userVrSets: UserVrSet[]) => {
    initialUserVrSets.current = [...userVrSets];
    setUserVrSets([...initialUserVrSets.current]);
    setIsUserVrSetsLoaded(true);
  };

  useEffect(() => {
    const userGuid: string = user?.userGuid ?? redirect("");
    getUserVrSets(userGuid, 15, 0)
      .then(applyFetchedUserVrSets)
      .catch(err => console.error("Error:", err));
  }, []);

  const requestSaveUserVrSets = () => {
    let userGuid: string = user?.userGuid ?? redirect("/");
    setIsUserVrSetsLoaded(false);
    requestSetUserVrSets(userGuid, userVrSets).then(() =>
      getUserVrSets(userGuid, 15, 0).then(applyFetchedUserVrSets)
    );
  };
  return {
    isUserVrSetsLoaded,
    initialUserVrSets,
    userVrSets,
    setUserVrSets,
    requestSaveUserVrSets,
  };
}
