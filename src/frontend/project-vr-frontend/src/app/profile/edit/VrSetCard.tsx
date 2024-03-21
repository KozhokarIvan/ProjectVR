import DeleteIcon from "@/components/icons/DeleteIcon";
import FavoriteIcon from "@/components/icons/FavoriteIcon";
import HoverIcon from "@/components/icons/HoverIcon";
import { UserVrSet } from "@/types";
import { Card } from "@nextui-org/react";

export interface VrSetCardProps {
  userVrSet: UserVrSet;
  removeVrSetFromUserVrSets: (userVrSet: UserVrSet) => void;
  addVrSetToFavorites: (userVrSet: UserVrSet) => void;
}

export default function VrSetCard({
  userVrSet,
  removeVrSetFromUserVrSets,
  addVrSetToFavorites,
}: VrSetCardProps) {
  return (
    <Card key={userVrSet.vrSetId} radius="none" className="mt-5 bg-transparent">
      <div className="relative">
        <div className="absolute flex right-0">
          <HoverIcon
            svgProps={{
              Icon: FavoriteIcon,
              props: {
                className: `${
                  userVrSet.isFavorite
                    ? "fill-primary hover:fill-none"
                    : "hover:fill-primary"
                } stroke-primary w-8 h-8`,
                onClick: () => addVrSetToFavorites(userVrSet),
              },
            }}
          />
          <HoverIcon
            svgProps={{
              Icon: DeleteIcon,
              props: {
                className: "w-8 h-8 hover:fill-danger",
                onClick: () => {
                  removeVrSetFromUserVrSets(userVrSet);
                },
              },
            }}
          />
        </div>
        <img src={userVrSet.vrSetIcon} />
      </div>
      <h6 className="text-center">{userVrSet.vrSetName}</h6>
      <div className="grid grid-cols-2"></div>
    </Card>
  );
}
