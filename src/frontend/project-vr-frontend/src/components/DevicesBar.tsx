import { VrSet } from "@/types";
import TitledIconsCard from "./TitledIconsCard";

export interface DevicesBarProps {
  devices: VrSet[];
}

export default function DevicesBar({ devices }: DevicesBarProps) {
  return (
    <TitledIconsCard
      title="Devices"
      items={devices.map(vrset => ({
        text: vrset.vrSetName,
        image: vrset.vrSetIcon,
        isFavorite: vrset.isFavorite,
      }))}
    />
  );
}
