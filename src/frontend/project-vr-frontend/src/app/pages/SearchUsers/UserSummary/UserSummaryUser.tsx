import { Grid, User } from "@nextui-org/react";

export interface UserSummaryUserProps {
  username: string;
  avatar?: string;
  vrset: string;
}
export default function UserSummaryUser(props: UserSummaryUserProps) {
  const { username, avatar, vrset } = props;

  return (
    <Grid.Container alignItems="flex-start" direction="column">
      <User
        name={username}
        src={avatar}
        description={vrset}
        squared
        pointer
        size="xl"
      />
    </Grid.Container>
  );
}
