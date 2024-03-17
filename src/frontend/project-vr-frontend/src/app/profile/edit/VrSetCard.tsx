import DeleteIcon from "@/components/icons/DeleteIcon";
import FavoriteIcon from "@/components/icons/FavoriteIcon";
import HoverIcon from "@/components/icons/HoverIcon";
import { VrSet } from "@/types";
import { Card } from "@nextui-org/react";
import { useState } from "react";

export interface VrSetCardProps {
  vrset: VrSet;
  vrSets: VrSet[];
  setVrSets: (vrSets: VrSet[]) => void;
}

export default function VrSetCard({
  vrset,
  vrSets,
  setVrSets,
}: VrSetCardProps) {
  const [vrSet, setVrSet] = useState<VrSet>(vrset);
  return (
    <Card key={vrSet.vrSetId} radius="none" className="mt-5 bg-transparent">
      <div className="relative">
        <div className="absolute flex right-0">
          <HoverIcon
            svgProps={{
              Icon: FavoriteIcon,
              props: {
                className: `${
                  vrSet.isFavorite
                    ? "fill-yellow-500 hover:fill-none"
                    : "hover:fill-yellow-500"
                } stroke-yellow-500 w-8 h-8`,
                onClick: () => {
                  setVrSet(oldVrset => {
                    return { ...oldVrset, isFavorite: !oldVrset.isFavorite };
                  });
                },
              },
            }}
          />
          <HoverIcon
            svgProps={{
              Icon: DeleteIcon,
              props: {
                className: "w-8 h-8 hover:fill-red-500",
                onClick: () => {
                  setVrSets(vrSets.filter(vs => vs.vrSetId != vrset.vrSetId));
                },
              },
            }}
          />
        </div>
        <img src={vrset.vrSetIcon} />
      </div>
      <h6 className="text-center">{vrset.vrSetName}</h6>
      <div className="grid grid-cols-2"></div>
    </Card>
  );
}
