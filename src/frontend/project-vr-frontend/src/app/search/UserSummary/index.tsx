import { Card, CardBody } from "@nextui-org/react";
import UserSummaryUser from "./User";
import UserSummaryBadges from "./Badges";
import UserSummaryInfo from "./Info";
import UserSummaryFooter from "./Footer";
import { UserInfo } from "@/types";

export interface UserSummaryProps {
  user: UserInfo;
}

export default function UserSummary({ user }: UserSummaryProps) {
  const { guid, avatar, username, vrSets, games, friendStatus } = user;

  return (
    <Card
      className="h-64 border-1 bg-transparent border-default-100 p-5"
      radius="none"
    >
      <CardBody>
        <div className="flex grow">
          <div className="flex">
            <UserSummaryUser
              avatar={avatar}
              username={username}
              vrset={vrSets[0]?.vrSetName}
            />
            <UserSummaryBadges vrsets={vrSets} games={games} />
          </div>
          <div className="flex flex-col basis-2/3">
            <UserSummaryInfo />
            <UserSummaryFooter userGuid={guid} status={friendStatus} />
          </div>
        </div>
      </CardBody>
    </Card>
  );
}
