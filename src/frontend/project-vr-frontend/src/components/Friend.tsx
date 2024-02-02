import { Avatar } from "@nextui-org/react";
import Link from "next/link";
import { Link as LinkComponent } from "@nextui-org/react";

export interface FriendProps {
  username: string;
  avatar?: string;
}

export default function Friend({ username, avatar }: FriendProps) {
  return (
    <div className="flex items-center">
      <Link href={`/users/${username}`}>
        <Avatar src={avatar} radius="none" isBordered size="lg" />
      </Link>
      <LinkComponent
        color="primary"
        className="ml-3 text-l"
        href={`/users/${username}`}
      >
        {username}
      </LinkComponent>
    </div>
  );
}
