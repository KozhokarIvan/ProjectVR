import { VrSet } from "@/types";
import { Button, ButtonProps, Divider, Spinner } from "@nextui-org/react";
import { useEffect, useRef, useState } from "react";
import VrSetCard from "./VrSetCard";
import { getUserVrSets, setUserVrSets } from "@/api/usersApi";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { redirect } from "next/navigation";

export interface EditDevicesSectionProps {
  className?: string;
}
enum TabState {
  Add,
  Remove,
}
export default function EditDevicesSection({
  className,
}: EditDevicesSectionProps) {
  const { user: loggedUser } = useLoggedUser();
  const [tab, setTab] = useState<TabState>(TabState.Remove);
  const [isVrSetsLoaded, setIsVrSetsLoaded] = useState<boolean>(false);
  const initialVrSets = useRef<VrSet[]>([]);
  const [vrSets, setVrSets] = useState<VrSet[]>([...initialVrSets.current]);
  const buttonProps: ButtonProps = {
    size: "lg",
    radius: "none",
    fullWidth: true,
    variant: "light",
  };
  const applyFetchedVrSets = (newVrSets: VrSet[]) => {
    initialVrSets.current = [...newVrSets];
    setVrSets([...initialVrSets.current]);
    setIsVrSetsLoaded(true);
  };
  useEffect(() => {
    let userGuid: string = loggedUser?.userGuid ?? redirect("/");
    getUserVrSets(userGuid, 15, 0)
      .then(applyFetchedVrSets)
      .catch(err => console.error("Error:", err));
    return setVrSets([]);
  }, []);
  const isSaveReasonable = () => {
    if (vrSets.length != initialVrSets.current.length) return true;
    for (let i = 0; i < vrSets.length; i++) {
      const initialVrSet = initialVrSets.current.find(
        vs => vs.vrSetId == vrSets[i].vrSetId
      );
      if (initialVrSet == null) return true;
      if (vrSets[i].isFavorite != initialVrSet.isFavorite) return true;
    }
    return false;
  };
  return (
    <div className={`self-start justify-self-stretch flex-1 ${className}`}>
      <h2 className="text-3xl text-center mb-4">Edit VrSets</h2>
      <Divider />
      <div className="grid grid-cols-2 text-center">
        <Button
          {...buttonProps}
          className="cursor-pointer text"
          color={tab == TabState.Add ? "success" : "default"}
          onClick={() => setTab(TabState.Add)}
        >
          Add
        </Button>
        <Button
          {...buttonProps}
          className="cursor-pointer text"
          color={tab == TabState.Remove ? "danger" : "default"}
          onClick={() => setTab(TabState.Remove)}
        >
          Remove
        </Button>
      </div>
      {isVrSetsLoaded ? (
        vrSets.length > 0 ? (
          <div className="grid grid-cols-3 gap-5">
            {vrSets.map(vrset => (
              <VrSetCard
                key={vrset.vrSetId}
                vrSet={vrset}
                vrSets={vrSets}
                setVrSets={setVrSets}
              />
            ))}
          </div>
        ) : (
          <h6 className="text-center text-2xl text-default-900">
            You have no vr sets
          </h6>
        )
      ) : (
        <div className="flex items-center justify-center">
          <Spinner size="lg" />
        </div>
      )}
      <div className="flex justify-between flex-row-reverse mt-8">
        <Button
          {...buttonProps}
          fullWidth={false}
          variant="ghost"
          color={isSaveReasonable() ? "danger" : "default"}
          onClick={() => setVrSets([...initialVrSets.current])}
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
            setUserVrSets(userGuid, vrSets).then(res =>
              getUserVrSets(userGuid, 15, 0).then(applyFetchedVrSets)
            );
          }}
          isDisabled={!isSaveReasonable()}
        >
          Save changes
        </Button>
      </div>
    </div>
  );
}
