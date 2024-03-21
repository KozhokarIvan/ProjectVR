import { UserVrSet } from "@/types";
import { Button, ButtonProps, Spinner } from "@nextui-org/react";
import { MutableRefObject } from "react";
import VrSetCard from "./VrSetCard";

export interface EditMyVrSetsProps {
  initialUserVrSets: MutableRefObject<UserVrSet[]>;
  isUserVrSetsLoaded: boolean;
  userVrSets: UserVrSet[];
  resetUserVrSets: () => void;
  requestSaveUserVrSets: () => void;
  removeVrSetFromUserVrSets: (userVrSet: UserVrSet) => void;
  addVrSetToFavorites: (userVrSet: UserVrSet) => void;
  buttonProps: ButtonProps;
  className?: string;
}
export default function EditMyVrSets({
  initialUserVrSets,
  isUserVrSetsLoaded,
  userVrSets,
  resetUserVrSets,
  requestSaveUserVrSets,
  removeVrSetFromUserVrSets,
  addVrSetToFavorites,
  buttonProps,
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
  if (!isUserVrSetsLoaded) {
    return (
      <div className={`flex items-center justify-center ${className}`}>
        <Spinner size="lg" />
      </div>
    );
  }
  buttonProps = {
    ...buttonProps,
    fullWidth: false,
    variant: "ghost",
    isDisabled: !isSaveReasonable(),
  };
  return (
    <>
      {userVrSets.length > 0 ? (
        <div className={`grid grid-cols-3 gap-5 ${className}`}>
          {userVrSets.map(vrset => (
            <VrSetCard
              key={vrset.vrSetId}
              userVrSet={vrset}
              removeVrSetFromUserVrSets={removeVrSetFromUserVrSets}
              addVrSetToFavorites={addVrSetToFavorites}
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
          color={isSaveReasonable() ? "danger" : "default"}
          onClick={() => resetUserVrSets()}
        >
          Reset changes
        </Button>
        <Button
          {...buttonProps}
          color={isSaveReasonable() ? "success" : "default"}
          onClick={() => requestSaveUserVrSets()}
        >
          Save changes
        </Button>
      </div>
    </>
  );
}
