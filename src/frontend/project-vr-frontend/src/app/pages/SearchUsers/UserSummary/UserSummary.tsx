import { Grid, Card } from "@nextui-org/react";
import UserSummaryUser from "./UserSummaryUser";
import UserSummaryBadges from "./UserSummaryBadges";
import UserSummaryInfo from "./UserSummaryInfo";
import UserSummaryFooter from "./UserSummaryFooter";
import { Game, VrSet } from "@/app/pages/SearchUsers/SearchUsers";

export interface UserSummary {
  avatar?: string;
  username: string;
  vrsets: VrSet[];
  games: Game[];
}

export default function UserSummary(props: UserSummary) {
  const { avatar, username, vrsets, games } = props;

  return (
    <Card>
      <Card.Body>
        <Grid.Container wrap="nowrap">
          <UserSummaryUser
            avatar={avatar}
            username={username}
            vrset={vrsets[0].name}
          />
          <UserSummaryBadges vrsets={vrsets} games={games} />
          <UserSummaryInfo />
        </Grid.Container>
      </Card.Body>
      <Card.Footer>
        <UserSummaryFooter />
      </Card.Footer>
    </Card>
  );
}
