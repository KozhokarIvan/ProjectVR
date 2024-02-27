import { Game } from "@/types";
import TitledIconsCard from "./TitledIconsCard";

export interface GamesBarProps {
  games: Game[];
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
