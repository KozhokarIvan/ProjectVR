import { getVrSets } from "@/api/vrSetsApi";
import { VrSet } from "@/types";
import {
  Dispatch,
  MutableRefObject,
  SetStateAction,
  useEffect,
  useRef,
  useState,
} from "react";
import {
  UseFetchUserVrSetsResult,
  useFetchUserVrSets,
} from "./use-fetch-user-vrsets";

export interface UseFetchVrSetsResult {
  isVrSetsLoaded: boolean;
  initialVrSets: MutableRefObject<VrSet[]>;
  vrSets: VrSet[];
  setVrSets: Dispatch<SetStateAction<VrSet[]>>;
  useFetchUserVrSetsResult: UseFetchUserVrSetsResult;
}

export function useFetchVrSets(): UseFetchVrSetsResult {
  const useFetchUserVrSetsResult = useFetchUserVrSets();
  const [isVrSetsLoaded, setIsVrSetsLoaded] = useState<boolean>(false);
  const initialVrSets = useRef<VrSet[]>([]);
  const [vrSets, setVrSets] = useState<VrSet[]>([]);

  useEffect(() => {
    getVrSets(15, 0)
      .then(vrSets => (initialVrSets.current = [...vrSets]))
      .catch(err => console.error("Error:", err));
  }, []);
  useEffect(() => {
    const filteredVrSets = initialVrSets.current.filter(
      vs =>
        !useFetchUserVrSetsResult.userVrSets.map(v => v.vrSetId).includes(vs.id)
    );
    setVrSets(filteredVrSets);
    setIsVrSetsLoaded(true);
  }, [useFetchUserVrSetsResult.isUserVrSetsLoaded]);

  return {
    isVrSetsLoaded,
    initialVrSets,
    vrSets,
    setVrSets,
    useFetchUserVrSetsResult,
  };
}
