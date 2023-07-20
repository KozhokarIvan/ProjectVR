import { Grid, Row } from "@nextui-org/react";
import UserSummaryBadge from "./UserSummaryBadge";
import { Game, VrSet } from "@/app/pages/SearchUsers/SearchUsers";

export interface UserSummaryBadgesProps {
  vrsets: VrSet[];
  games: Game[];
}

export default function UserSummaryBadges(props: UserSummaryBadgesProps) {
  let { vrsets, games } = props;

  return (
    <Grid.Container
      direction="column"
      justify="center"
      alignItems="center"
      css={{ gap: "10px" }}
    >
      <Row css={{ gap: "10px" }}>
        {vrsets.slice(0, 3).map(vrset => (
          <UserSummaryBadge
            key={vrset.vrSetId}
            text={vrset.name}
            image={vrset.icon ?? ""}
            isFavorite={vrset.isFavorite}
          />
        ))}
      </Row>

      <Row css={{ gap: "10px" }}>
        {games.slice(0, 3).map(game => (
          <UserSummaryBadge
            key={game.gameId}
            text={game.name}
            image={game.icon ?? ""}
            isFavorite={game.isFavorite}
          />
        ))}
      </Row>
    </Grid.Container>
  );
}
