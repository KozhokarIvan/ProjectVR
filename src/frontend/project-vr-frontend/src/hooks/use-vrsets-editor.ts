import { UserVrSet, VrSet } from "@/types";
import {
  Dispatch,
  MutableRefObject,
  SetStateAction,
  useEffect,
  useState,
} from "react";
import { useFetchVrSets } from "./use-fetch-vrsets";

export interface VrSetsEditor {
  initialVrSets: MutableRefObject<VrSet[]>;
  initialUserVrSets: MutableRefObject<UserVrSet[]>;
  isUserVrSetsLoaded: boolean;
  vrSets: VrSet[];
  setVrSets: Dispatch<SetStateAction<VrSet[]>>;
  userVrSets: UserVrSet[];
  setUserVrSets: Dispatch<SetStateAction<UserVrSet[]>>;
  isVrSetsLoaded: boolean;
  selectedVrSets: VrSet[];
  setSelectedVrSets: Dispatch<SetStateAction<VrSet[]>>;
  addSelectionToUserVrSets: () => void;
  cancelSelection: () => void;
  addVrSetToSelection: (vrSet: VrSet) => void;
  resetUserVrSets: () => void;
  requestSaveUserVrSets: () => void;
  removeVrSetFromUserVrSets: (userVrSet: UserVrSet) => void;
  addVrSetToFavorites: (userVrSet: UserVrSet) => void;
}

export function useVrSetsEditor(): VrSetsEditor {
  const {
    isVrSetsLoaded,
    initialVrSets,
    vrSets,
    setVrSets,
    useFetchUserVrSetsResult,
  } = useFetchVrSets();
  const {
    isUserVrSetsLoaded,
    initialUserVrSets,
    userVrSets,
    setUserVrSets,
    requestSaveUserVrSets,
  } = useFetchUserVrSetsResult;

  const [selectedVrSets, setSelectedVrSets] = useState<VrSet[]>([]);

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
    setSelectedVrSets([]);
  }, [vrSets, userVrSets]);
  return {
    initialVrSets,
    initialUserVrSets,
    isUserVrSetsLoaded,
    vrSets,
    setVrSets,
    userVrSets,
    setUserVrSets,
    isVrSetsLoaded,
    selectedVrSets,
    setSelectedVrSets,
    addSelectionToUserVrSets,
    cancelSelection,
    addVrSetToSelection,
    resetUserVrSets,
    requestSaveUserVrSets,
    removeVrSetFromUserVrSets,
    addVrSetToFavorites,
  };
}
