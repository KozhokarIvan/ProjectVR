import { UserVrSet, VrSet } from "@/types";
import { Button, ButtonProps, Divider, Spinner } from "@nextui-org/react";
import { useEffect, useRef, useState } from "react";
import { getUserVrSets, setUserVrSets } from "@/api/usersApi";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { redirect } from "next/navigation";
import EditMyVrSets from "./EditMyVrSets";
import AddNewVrSets from "./AddNewVrSets";
import { getVrSets } from "@/api/vrSetsApi";

export interface EditDevicesSectionProps {
  className?: string;
}
enum TabState {
  MyVrSets,
  FindVrSets,
}
export default function EditDevicesSection({
  className,
}: EditDevicesSectionProps) {
  const { user: loggedUser } = useLoggedUser();
  const [tab, setTab] = useState<TabState>(TabState.MyVrSets);
  const [isUserVrSetsLoaded, setIsUserVrSetsLoaded] = useState<boolean>(false);
  const initialUserVrSets = useRef<UserVrSet[]>([]);
  const [userVrSets, setUserVrSets] = useState<UserVrSet[]>([]);
  const [isVrSetsLoaded, setIsVrSetsLoaded] = useState<boolean>(false);
  const initialVrSets = useRef<VrSet[]>([]);
  const [vrSets, setVrSets] = useState<VrSet[]>([]);
  const [selectedVrSets, setSelectedVrSets] = useState<VrSet[]>([]);
  const [selectedKeys, setSelectedKeys] = useState<any>();
  const buttonProps: ButtonProps = {
    size: "lg",
    radius: "none",
    fullWidth: true,
    variant: "light",
  };
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
  useEffect(() => {
    let userGuid: string = loggedUser?.userGuid ?? redirect("/");
    let getUserVrSetsTask = getUserVrSets(userGuid, 15, 0);
    let getVrSetsTask = getVrSets(15, 0);
    getUserVrSetsTask
      .then(userVrSets => {
        applyFetchedUserVrSets(userVrSets);
        getVrSetsTask
          .then(vrSets => applyFetchedVrSets(vrSets, userVrSets))
          .catch(err => console.error("Error:", err));
      })
      .catch(err => console.error("Error:", err));
  }, []);

  return (
    <div className={`self-start justify-self-stretch flex-1 ${className}`}>
      <h2 className="text-3xl text-center mb-4">Edit VrSets</h2>
      <Divider />
      <div className="grid grid-cols-2 text-center">
        <Button
          {...buttonProps}
          className="cursor-pointer text"
          color={tab == TabState.MyVrSets ? "primary" : "default"}
          onClick={() => setTab(TabState.MyVrSets)}
        >
          My VrSets
        </Button>
        <Button
          {...buttonProps}
          className="cursor-pointer text"
          color={tab == TabState.FindVrSets ? "primary" : "default"}
          onClick={() => setTab(TabState.FindVrSets)}
        >
          Add VrSets
        </Button>
      </div>
      <EditMyVrSets
        isVrSetsLoaded={isUserVrSetsLoaded}
        setIsVrSetsLoaded={setIsUserVrSetsLoaded}
        applyFetchedVrSets={applyFetchedUserVrSets}
        initialUserVrSets={initialUserVrSets}
        userVrSets={userVrSets}
        setUserVrSets={setUserVrSets}
        initialVrSets={initialVrSets}
        vrSets={vrSets}
        setVrSets={setVrSets}
        selectedVrSets={selectedVrSets}
        setSelectedKeys={setSelectedKeys}
        buttonProps={buttonProps}
        loggedUser={loggedUser}
        className={tab == TabState.MyVrSets ? "" : "hidden"}
      />
      <AddNewVrSets
        vrSets={vrSets}
        setVrSets={setVrSets}
        isVrSetsLoaded={isVrSetsLoaded}
        userVrSets={userVrSets}
        setUserVrSets={setUserVrSets}
        selectedVrSets={selectedVrSets}
        setSelectedVrSets={setSelectedVrSets}
        selectedKeys={selectedKeys}
        setSelectedKeys={setSelectedKeys}
        buttonProps={buttonProps}
        className={tab == TabState.FindVrSets ? "" : "hidden"}
      />
    </div>
  );
}
