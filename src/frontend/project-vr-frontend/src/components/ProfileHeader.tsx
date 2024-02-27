import FriendButton from "@/components/FriendButton";
import { FriendStatus } from "@/types/enums/FriendStatus";
import { Card, CardBody } from "@nextui-org/card";
import { Avatar, Button } from "@nextui-org/react";
import { useRouter } from "next/navigation";
export interface ProfileHeaderProps {
  userGuid: string;
  username: string;
  avatar?: string;
  registeredAt: Date;
  friendStatus: FriendStatus;
  isEditableProfile?: boolean;
}

export default function ProfileHeader({
  userGuid,
  username,
  avatar,
  registeredAt,
  friendStatus,
  isEditableProfile,
}: ProfileHeaderProps) {
  const router = useRouter();
  return (
    <Card
      radius="none"
      className="bg-transparent mt-8 border-1.5 border-default"
    >
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
          {isEditableProfile ? (
            <Button
              variant="ghost"
              color="default"
              radius="none"
              size="lg"
              onClick={() => {
                router.push("/profile/edit");
              }}
            >
              Edit profile
            </Button>
          ) : (
            <FriendButton
              userGuid={userGuid}
              friendStatus={friendStatus}
              size="lg"
              radius="none"
              variant="ghost"
            />
          )}
        </div>
      </CardBody>
    </Card>
  );
}
