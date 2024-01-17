import FriendButton, { FriendButtonProps } from "@/components/FriendButton";
import { FriendStatus } from "@/types/enums/FriendStatus";

export interface UserSummaryFooterProps {
  userGuid: string;
  status: FriendStatus;
}

export default function UserSummaryFooter({
  userGuid,
  status,
}: UserSummaryFooterProps) {
  return (
    <div className="flex justify-end">
      <FriendButton
        size="md"
        userGuid={userGuid}
        friendStatus={status}
        variant="ghost"
        radius="sm"
      />
    </div>
  );
}
