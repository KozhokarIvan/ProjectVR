import { UserGame } from "@/types";
import TitledIconsCard from "./TitledIconsCard";

export interface GamesBarProps {
  games: UserGame[];
}

export default function GamesBar({ games }: GamesBarProps) {
  return (
    <TitledIconsCard
      title="Games"
      items={games.map(game => ({
        text: game.gameName,
        image: game.gameIcon,
        isFavorite: game.isFavorite,
      }))}
    />
  );
}
