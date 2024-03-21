import {
  Dispatch,
  MutableRefObject,
  SetStateAction,
  useEffect,
  useRef,
  useState,
} from "react";
import { useLoggedUser } from "./use-logged-user";
import { UserVrSet, VrSet } from "@/types";
import { getUserVrSets } from "@/api/usersApi";
import { getVrSets } from "@/api/vrSetsApi";
import { redirect } from "next/navigation";
import { setUserVrSets as requestSetUserVrSets } from "@/api/usersApi";
export interface VrSetsEditor {
  initialVrSets: MutableRefObject<VrSet[]>;
  initialUserVrSets: MutableRefObject<UserVrSet[]>;
  isUserVrSetsLoaded: boolean;
  setIsUserVrSetsLoaded: Dispatch<SetStateAction<boolean>>;
  vrSets: VrSet[];
  setVrSets: Dispatch<SetStateAction<VrSet[]>>;
  userVrSets: UserVrSet[];
  setUserVrSets: Dispatch<SetStateAction<UserVrSet[]>>;
  isVrSetsLoaded: boolean;
  setIsVrSetsLoaded: Dispatch<SetStateAction<boolean>>;
  selectedVrSets: VrSet[];
  setSelectedVrSets: Dispatch<SetStateAction<VrSet[]>>;
  applyFetchedUserVrSets: (userVrSets: UserVrSet[]) => void;
  addSelectionToUserVrSets: () => void;
  cancelSelection: () => void;
  addVrSetToSelection: (vrSet: VrSet) => void;
  resetUserVrSets: () => void;
  requestSaveUserVrSets: () => void;
  removeVrSetFromUserVrSets: (userVrSet: UserVrSet) => void;
  addVrSetToFavorites: (userVrSet: UserVrSet) => void;
}

export function useVrSetsEditor(): VrSetsEditor {
  const { user: loggedUser } = useLoggedUser();
  const [isUserVrSetsLoaded, setIsUserVrSetsLoaded] = useState<boolean>(false);
  const initialUserVrSets = useRef<UserVrSet[]>([]);
  const [userVrSets, setUserVrSets] = useState<UserVrSet[]>([]);
  const [isVrSetsLoaded, setIsVrSetsLoaded] = useState<boolean>(false);
  const initialVrSets = useRef<VrSet[]>([]);
  const [vrSets, setVrSets] = useState<VrSet[]>([]);
  const [selectedVrSets, setSelectedVrSets] = useState<VrSet[]>([]);
  const applyFetchedUserVrSets = (userVrSets: UserVrSet[]) => {
    initialUserVrSets.current = [...userVrSets];
    setUserVrSets([...initialUserVrSets.current]);
    setIsUserVrSetsLoaded(true);
  };
  const applyFetchedVrSets = (vrSets: VrSet[], userVrSets: UserVrSet[]) => {
    initialVrSets.current = [...vrSets];
    const filteredVrSets = initialVrSets.current.filter(
      vs => !userVrSets.map(v => v.vrSetId).includes(vs.id)
    );
    setVrSets(filteredVrSets);
    setIsVrSetsLoaded(true);
  };
  const addSelectionToUserVrSets = () => {
    setUserVrSets([
      ...userVrSets,
      ...selectedVrSets.map(vs => {
        return {
          vrSetId: vs.id,
          vrSetName: vs.name,
          vrSetIcon: vs.icon,
          isFavorite: false,
        };
      }),
    ]);
    setVrSets(
      vrSets.filter(vs => !selectedVrSets.map(v => v.id).includes(vs.id))
    );
  };
  const cancelSelection = () => {
    setSelectedVrSets([]);
  };
  const addVrSetToSelection = (vrSet: VrSet) => {
    if (selectedVrSets.map(v => v.id).includes(vrSet.id))
      setSelectedVrSets(selectedVrSets.filter(v => v.id != vrSet.id));
    else setSelectedVrSets([...selectedVrSets, vrSet]);
  };
  const resetUserVrSets = () => {
    setUserVrSets([...initialUserVrSets.current]);
    const filteredVrSets = initialVrSets.current.filter(
      vs => !initialUserVrSets.current.map(v => v.vrSetId).includes(vs.id)
    );
    setVrSets(filteredVrSets);
  };
  const requestSaveUserVrSets = () => {
    let userGuid: string = loggedUser?.userGuid ?? redirect("/");
    setIsUserVrSetsLoaded(false);
    requestSetUserVrSets(userGuid, userVrSets).then(res =>
      getUserVrSets(userGuid, 15, 0).then(applyFetchedUserVrSets)
    );
  };
  const removeVrSetFromUserVrSets = (userVrSet: UserVrSet) => {
    setUserVrSets(userVrSets.filter(vs => vs.vrSetId != userVrSet.vrSetId));
    setVrSets([
      ...vrSets,
      {
        id: userVrSet.vrSetId,
        name: userVrSet.vrSetName,
        icon: userVrSet.vrSetIcon,
      },
    ]);
  };
  const addVrSetToFavorites = (userVrSet: UserVrSet) => {
    const newVrSets = userVrSets.map(vs =>
      vs.vrSetId == userVrSet.vrSetId
        ? { ...vs, isFavorite: !vs.isFavorite }
        : vs
    );
    setUserVrSets(newVrSets);
  };
  useEffect(() => {
    const userGuid: string = loggedUser?.userGuid ?? redirect("/");
    const getUserVrSetsTask = getUserVrSets(userGuid, 15, 0);
    const getVrSetsTask = getVrSets(15, 0);
    getUserVrSetsTask
      .then(userVrSets => {
        applyFetchedUserVrSets(userVrSets);
        getVrSetsTask
          .then(vrSets => applyFetchedVrSets(vrSets, userVrSets))
          .catch(err => console.error("Error:", err));
      })
      .catch(err => console.error("Error:", err));
  }, []);
  useEffect(() => {
    setSelectedVrSets([]);
  }, [vrSets, userVrSets]);
  return {
    initialVrSets,
    initialUserVrSets,
    isUserVrSetsLoaded,
    setIsUserVrSetsLoaded,
    vrSets: vrSets,
    setVrSets: setVrSets,
    userVrSets: userVrSets,
    setUserVrSets: setUserVrSets,
    isVrSetsLoaded: isVrSetsLoaded,
    setIsVrSetsLoaded,
    selectedVrSets,
    setSelectedVrSets,
    applyFetchedUserVrSets,
    addSelectionToUserVrSets,
    cancelSelection,
    addVrSetToSelection,
    resetUserVrSets,
    requestSaveUserVrSets,
    removeVrSetFromUserVrSets,
    addVrSetToFavorites,
  };
}
