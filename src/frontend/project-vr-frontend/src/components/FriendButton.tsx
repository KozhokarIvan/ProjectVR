"use client";
import { useLoggedUser } from "@/hooks/use-logged-user";
import {
  acceptFriend,
  addFriend,
  declineFriend,
  removeFriend,
} from "@/api/friendsApi";
import { FriendStatus } from "@/types/enums/FriendStatus";
import { Color, ButtonRadius, ButtonSize, ButtonVariant } from "@/types/nextui";
import { Button } from "@nextui-org/react";
import { AppRouterInstance } from "next/dist/shared/lib/app-router-context.shared-runtime";
import { useRouter } from "next/navigation";
import { useState } from "react";

export interface FriendButtonProps {
  userGuid: string;
  friendStatus: FriendStatus;
  size: ButtonSize;
  variant: ButtonVariant;
  radius: ButtonRadius;
  className?: string;
}

export default function FriendButton({
  userGuid,
  friendStatus,
  size,
  variant,
  radius,
  className,
}: FriendButtonProps) {
  const [status, setStatus] = useState(friendStatus);
  const [isLoading, setIsLoading] = useState(false);
  const { user: loggedUser } = useLoggedUser();
  const color = getButtonColor(status);
  const text = getButtonText(status);
  const router = useRouter();
  const clickHandler = getOnClickAction(
    status,
    userGuid,
    loggedUser?.userGuid ?? "",
    router,
    setIsLoading,
    setStatus
  );
  return status != FriendStatus.Self ? (
    <Button
      variant={variant}
      color={color}
      radius={radius}
      size={size}
      isLoading={isLoading}
      onClick={clickHandler}
      className={className}
    >
      {text}
    </Button>
  ) : (
    ""
  );
}

const getButtonColor = (status: FriendStatus): Color => {
  switch (status) {
    case FriendStatus.Stranger:
    case FriendStatus.Incoming:
      return "success";
    case FriendStatus.Friend:
      return "danger";
    case FriendStatus.Outgoing:
      return "warning";
    case FriendStatus.Self:
    case FriendStatus.Unauthorized:
    case FriendStatus.Undefined:
      return "default";
  }
};
const getButtonText = (status: FriendStatus): string => {
  switch (status) {
    case FriendStatus.Unauthorized:
      return "Sign In to add friends";
    case FriendStatus.Stranger:
      return "Add to friends";
    case FriendStatus.Friend:
      return "Remove from friends";
    case FriendStatus.Outgoing:
      return "Cancel request";
    case FriendStatus.Incoming:
      return "Accept request";
    case FriendStatus.Self:
      return "Its you !";
    case FriendStatus.Undefined:
      return "Error";
  }
};
const getOnClickAction = (
  status: FriendStatus,
  friendGuid: string,
  loggedUserGuid: string,
  router: AppRouterInstance,
  setIsLoading: (isLoading: boolean) => void,
  setStatus: (status: FriendStatus) => void
) => {
  switch (status) {
    case FriendStatus.Unauthorized:
      return () => {
        setIsLoading(true);
        router.push("/login");
      };
    case FriendStatus.Stranger:
      return () => {
        setIsLoading(true);
        addFriend(loggedUserGuid, friendGuid)
          .then(({ data: success }) => {
            if (success) setStatus(FriendStatus.Outgoing);
          })
          .finally(() => {
            setIsLoading(false);
          });
      };
    case FriendStatus.Friend:
      return () => {
        setIsLoading(true);
        removeFriend(loggedUserGuid, friendGuid)
          .then(({ data: success }) => {
            if (success) setStatus(FriendStatus.Incoming);
          })
          .finally(() => {
            setIsLoading(false);
          });
      };
    case FriendStatus.Outgoing:
      return () => {
        setIsLoading(true);
        declineFriend(loggedUserGuid, friendGuid)
          .then(({ data: success }) => {
            if (success) setStatus(FriendStatus.Stranger);
          })
          .finally(() => {
            setIsLoading(false);
          });
      };
    case FriendStatus.Incoming:
      return () => {
        setIsLoading(true);
        acceptFriend(loggedUserGuid, friendGuid)
          .then(({ data: success }) => {
            if (success) setStatus(FriendStatus.Friend);
          })
          .finally(() => {
            setIsLoading(false);
          });
      };
    case FriendStatus.Self:
    case FriendStatus.Undefined:
      return () => {};
  }
};
