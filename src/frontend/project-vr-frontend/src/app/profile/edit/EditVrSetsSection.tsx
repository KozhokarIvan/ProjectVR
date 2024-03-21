import { useVrSetsEditor } from "@/hooks/user-vrsets-editor";
import { Button, ButtonProps, Divider } from "@nextui-org/react";
import { useState } from "react";
import AddNewVrSets from "./AddNewVrSets";
import EditMyVrSets from "./EditMyVrSets";

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
  const [tab, setTab] = useState<TabState>(TabState.MyVrSets);
  const buttonProps: ButtonProps = {
    size: "lg",
    radius: "none",
    fullWidth: true,
    variant: "light",
  };
  const vrSetsEditor = useVrSetsEditor();

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
        initialUserVrSets={vrSetsEditor.initialUserVrSets}
        isUserVrSetsLoaded={vrSetsEditor.isUserVrSetsLoaded}
        userVrSets={vrSetsEditor.userVrSets}
        resetUserVrSets={vrSetsEditor.resetUserVrSets}
        requestSaveUserVrSets={vrSetsEditor.requestSaveUserVrSets}
        removeVrSetFromUserVrSets={vrSetsEditor.removeVrSetFromUserVrSets}
        addVrSetToFavorites={vrSetsEditor.addVrSetToFavorites}
        buttonProps={buttonProps}
        className={tab == TabState.MyVrSets ? "" : "hidden"}
      />
      <AddNewVrSets
        vrSets={vrSetsEditor.vrSets}
        isVrSetsLoaded={vrSetsEditor.isVrSetsLoaded}
        userVrSets={vrSetsEditor.userVrSets}
        selectedVrSets={vrSetsEditor.selectedVrSets}
        addSelectionToUserVrSets={vrSetsEditor.addSelectionToUserVrSets}
        cancelSelection={vrSetsEditor.cancelSelection}
        addVrSetToSelection={vrSetsEditor.addVrSetToSelection}
        buttonProps={buttonProps}
        className={tab == TabState.FindVrSets ? "" : "hidden"}
      />
    </div>
  );
}
