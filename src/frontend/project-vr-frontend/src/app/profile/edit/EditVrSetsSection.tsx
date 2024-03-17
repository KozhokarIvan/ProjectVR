import DeleteIcon from "@/components/icons/DeleteIcon";
import FavoriteIcon from "@/components/icons/FavoriteIcon";
import HoverIcon from "@/components/icons/HoverIcon";
import { VrSet } from "@/types";
import { Button, ButtonProps, Card } from "@nextui-org/react";
import { useState } from "react";
import VrSetCard from "./VrSetCard";

export interface EditDevicesSectionProps {
  className?: string;
}
enum TabState {
  Add,
  Remove,
}
const initialVrSets: VrSet[] = [
  {
    vrSetId: 1,
    vrSetName: "Meta Quest 2",
    vrSetIcon:
      "https://static.insales-cdn.com/images/products/1/3346/464268562/Oculus-Quest-2-256GB-Gogle-Okulary-VR-od-reki-FV23-EAN-0815820021346.jfif",
    isFavorite: true,
  },
  {
    vrSetId: 2,
    vrSetName: "Meta Quest 3",
    vrSetIcon:
      "https://static.insales-cdn.com/images/products/1/3346/464268562/Oculus-Quest-2-256GB-Gogle-Okulary-VR-od-reki-FV23-EAN-0815820021346.jfif",
    isFavorite: false,
  },
  {
    vrSetId: 3,
    vrSetName: "Meta Quest 2",
    vrSetIcon:
      "https://static.insales-cdn.com/images/products/1/3346/464268562/Oculus-Quest-2-256GB-Gogle-Okulary-VR-od-reki-FV23-EAN-0815820021346.jfif",
    isFavorite: false,
  },
];
export default function EditDevicesSection({
  className,
}: EditDevicesSectionProps) {
  const [tab, setTab] = useState<TabState>(TabState.Remove);
  const [vrSets, setVrSets] = useState<VrSet[]>(initialVrSets);
  const buttonProps: ButtonProps = {
    size: "lg",
    radius: "none",
    fullWidth: true,
    variant: "light",
  };
  return (
    <div className={`self-start justify-self-stretch flex-1 ${className}`}>
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
      <div className="grid grid-cols-3 gap-5">
        {vrSets.map(vrset => (
          <VrSetCard
            key={vrset.vrSetId}
            vrset={vrset}
            vrSets={vrSets}
            setVrSets={setVrSets}
          />
        ))}
      </div>
    </div>
  );
}
