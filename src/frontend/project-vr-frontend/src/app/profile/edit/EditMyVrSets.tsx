import { AuthUser, UserVrSet, VrSet } from "@/types";
import VrSetCard from "./VrSetCard";
import { Button, ButtonProps, Spinner } from "@nextui-org/react";
import { MutableRefObject, SetStateAction } from "react";
import { redirect } from "next/navigation";
import {
  getUserVrSets,
  setUserVrSets as requestSetUserVrSets,
} from "@/api/usersApi";

export interface EditMyVrSetsProps {
  isVrSetsLoaded: boolean;
  setIsVrSetsLoaded: (value: SetStateAction<boolean>) => void;
  applyFetchedVrSets: (newVrSets: UserVrSet[]) => void;
  initialUserVrSets: MutableRefObject<UserVrSet[]>;
  userVrSets: UserVrSet[];
  setUserVrSets: (value: SetStateAction<UserVrSet[]>) => void;
  initialVrSets: MutableRefObject<VrSet[]>;
  vrSets: VrSet[];
  setVrSets: (value: SetStateAction<VrSet[]>) => void;
  selectedVrSets: VrSet[];
  setSelectedKeys: (value: SetStateAction<any>) => void;
  buttonProps: ButtonProps;
  loggedUser: AuthUser | null;
  className?: string;
}
export default function EditMyVrSets({
  isVrSetsLoaded,
  initialUserVrSets,
  userVrSets,
  setUserVrSets,
  initialVrSets,
  vrSets,
  setVrSets,
  setIsVrSetsLoaded,
  selectedVrSets,
  setSelectedKeys,
  buttonProps,
  loggedUser,
  applyFetchedVrSets,
  className,
}: EditMyVrSetsProps) {
  const isSaveReasonable = () => {
    if (userVrSets.length != initialUserVrSets.current.length) return true;
    for (let i = 0; i < userVrSets.length; i++) {
      const initialVrSet = initialUserVrSets.current.find(
        vs => vs.vrSetId == userVrSets[i].vrSetId
      );
      if (initialVrSet == null) return true;
      if (userVrSets[i].isFavorite != initialVrSet.isFavorite) return true;
    }
    return false;
  };
  if (!isVrSetsLoaded) {
    return (
      <div className={`flex items-center justify-center ${className}`}>
        <Spinner size="lg" />
      </div>
    );
  }
  return (
    <>
      {userVrSets.length > 0 ? (
        <div className={`grid grid-cols-3 gap-5 ${className}`}>
          {userVrSets.map(vrset => (
            <VrSetCard
              key={vrset.vrSetId}
              vrSet={vrset}
              vrSets={userVrSets}
              setVrSets={setUserVrSets}
            />
          ))}
        </div>
      ) : (
        <h6 className={`text-center text-2xl text-default-900 ${className}`}>
          You have no vr sets
        </h6>
      )}
      <div
        className={`flex justify-between flex-row-reverse mt-8 ${className}`}
      >
        <Button
          {...buttonProps}
          fullWidth={false}
          variant="ghost"
          color={isSaveReasonable() ? "danger" : "default"}
          onClick={() => {
            setUserVrSets([...initialUserVrSets.current]);
            const filteredVrSets = initialVrSets.current.filter(
              vs =>
                !initialUserVrSets.current.map(v => v.vrSetId).includes(vs.id)
            );
            setVrSets(filteredVrSets);
            setSelectedKeys([]);
          }}
          isDisabled={!isSaveReasonable()}
        >
          Reset changes
        </Button>
        <Button
          {...buttonProps}
          fullWidth={false}
          variant="ghost"
          color={isSaveReasonable() ? "success" : "default"}
          onClick={() => {
            let userGuid: string = loggedUser?.userGuid ?? redirect("/");
            setIsVrSetsLoaded(false);
            requestSetUserVrSets(userGuid, userVrSets).then(res =>
              getUserVrSets(userGuid, 15, 0).then(applyFetchedVrSets)
            );
          }}
          isDisabled={!isSaveReasonable()}
        >
          Save changes
        </Button>
      </div>
    </>
  );
}
