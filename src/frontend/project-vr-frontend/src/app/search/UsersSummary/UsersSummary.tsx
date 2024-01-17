import { Spacer } from "@nextui-org/react";
import { UserInfo } from "@/types";
import UserSummary from "../UserSummary";

export interface UsersSummary {
  users: UserInfo[];
}

export default function UsersSummary(props: UsersSummary) {
  const users = props.users;

  return (
    <>
      {users.map(user => {
        return (
          <div key={user.guid} className="grid gap-10 mx-60">
            <UserSummary user={user} />
            <Spacer y={1} />
          </div>
        );
      })}
    </>
  );
}
