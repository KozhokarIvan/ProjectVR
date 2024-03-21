import DeleteIcon from "@/components/icons/DeleteIcon";
import FavoriteIcon from "@/components/icons/FavoriteIcon";
import HoverIcon from "@/components/icons/HoverIcon";
import { UserVrSet } from "@/types";
import { Card } from "@nextui-org/react";

export interface VrSetCardProps {
  vrSet: UserVrSet;
  vrSets: UserVrSet[];
  setVrSets: (vrSets: UserVrSet[]) => void;
}

export default function VrSetCard({
  vrSet,
  vrSets,
  setVrSets,
}: VrSetCardProps) {
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
                    ? "fill-primary hover:fill-none"
                    : "hover:fill-primary"
                } stroke-primary w-8 h-8`,
                onClick: () => {
                  const newVrSets = vrSets.map(vs =>
                    vs.vrSetId == vrSet.vrSetId
                      ? { ...vs, isFavorite: !vs.isFavorite }
                      : vs
                  );
                  setVrSets(newVrSets);
                },
              },
            }}
          />
          <HoverIcon
            svgProps={{
              Icon: DeleteIcon,
              props: {
                className: "w-8 h-8 hover:fill-danger",
                onClick: () => {
                  setVrSets(vrSets.filter(vs => vs.vrSetId != vrSet.vrSetId));
                },
              },
            }}
          />
        </div>
        <img src={vrSet.vrSetIcon} />
      </div>
      <h6 className="text-center">{vrSet.vrSetName}</h6>
      <div className="grid grid-cols-2"></div>
    </Card>
  );
}
