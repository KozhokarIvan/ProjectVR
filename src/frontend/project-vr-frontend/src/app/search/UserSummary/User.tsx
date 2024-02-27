import { Avatar, Link } from "@nextui-org/react";

export interface UserSummaryUserProps {
  username: string;
  avatar?: string;
  vrset: string;
}
export default function UserSummaryUser(props: UserSummaryUserProps) {
  const { username, avatar, vrset } = props;

  return (
    <div className="flex items-stretch flex-col w-52">
      <div className="flex">
        <Link
          href={`/users/${username}`}
          color="primary"
          size="sm"
          className="font-semibold"
        >
          <Avatar
            radius="sm"
            size="lg"
            showFallback
            src={avatar}
            alt={username}
          />
        </Link>
        <div className="ml-2 flex flex-col justify-evenly">
          <Link
            href={`/users/${username}`}
            color="primary"
            size="sm"
            className="font-semibold"
          >
            {username}
          </Link>
          <p className="text-tiny text-foreground-400">{vrset}</p>
        </div>
      </div>
    </div>
  );
}
