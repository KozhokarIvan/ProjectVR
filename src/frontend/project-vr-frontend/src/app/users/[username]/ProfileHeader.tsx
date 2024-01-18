"use client";
import FriendButton from "@/components/FriendButton";
import { FriendStatus } from "@/types/enums/FriendStatus";
import { Card, CardBody } from "@nextui-org/card";
import { Avatar, Image } from "@nextui-org/react";
export interface ProfileHeaderProps {
  userGuid: string;
  username: string;
  avatar?: string;
  registeredAt: Date;
  friendStatus: FriendStatus;
}

export default function ProfileHeader({
  userGuid,
  username,
  avatar,
  registeredAt,
  friendStatus,
}: ProfileHeaderProps) {
  return (
    <Card radius="none">
      <CardBody className="h-60 flex items-start justify-center">
        <div className="flex justify-center items-stretch h-full">
          <Avatar
            className="w-32 h-32"
            size="lg"
            alt={username}
            src={avatar}
            radius="none"
            isBordered
          />
          <div className="ml-4">
            <p className="text-2xl">{username}</p>
            <div className="mt-2 flex flex-col justify-between text-sm text-gray-300">
              <p>Joined at</p>
              <p>{registeredAt.toLocaleString()}</p>
            </div>
          </div>
        </div>
        <div className="self-end">
          <FriendButton
            userGuid={userGuid}
            friendStatus={friendStatus}
            size="lg"
            radius="none"
            variant="ghost"
          />
        </div>
      </CardBody>
    </Card>
  );
}
