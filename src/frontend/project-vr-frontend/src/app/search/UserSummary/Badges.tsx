import { Game, VrSet } from "@/types";
import Icon from "../../../components/Icon";
export interface UserSummaryBadgesProps {
  vrsets: VrSet[];
  games: Game[];
}

export default function UserSummaryBadges(props: UserSummaryBadgesProps) {
  let { vrsets, games } = props;
  return (
    <div className="w-44 m-8 self-center grid gap-3">
      <div className="grid gap-3 grid-cols-3">
        {vrsets
          .sort(vrset => (vrset.isFavorite ? 0 : 1))
          .slice(0, 3)
          .map(vrset => (
            <Icon
              key={vrset.vrSetId}
              text={vrset.vrSetName}
              image={vrset.vrSetIcon ?? ""}
              isFavorite={vrset.isFavorite}
            />
          ))}
      </div>
      <div className="grid gap-3 grid-cols-3">
        {games
          .sort(game => (game.isFavorite ? 0 : 1))
          .slice(0, 3)
          .map(game => (
            <Icon
              key={game.gameId}
              text={game.gameName}
              image={game.gameIcon ?? ""}
              isFavorite={game.isFavorite}
            />
          ))}
      </div>
    </div>
  );
}
