import { Card, CardBody } from "@nextui-org/react";
import UserSummaryUser from "./UserSummaryUser";
import UserSummaryBadges from "./UserSummaryBadges";
import UserSummaryInfo from "./UserSummaryInfo";
import UserSummaryFooter from "./UserSummaryFooter";
import { UserSummary } from "@/types";
export default function UserSummary(props: UserSummary) {
  const { avatar, username, vrsets, games } = props;

  return (
    <Card className="h-64">
      <CardBody>
        <div className="flex grow">
          <div className="flex">
            <UserSummaryUser
              avatar={avatar}
              username={username}
              vrset={vrsets[0].vrSetName}
            />
            <UserSummaryBadges vrsets={vrsets} games={games} />
          </div>
          <div className="flex flex-col basis-2/3">
            <UserSummaryInfo />
            <UserSummaryFooter />
          </div>
        </div>
      </CardBody>
    </Card>
  );
}
