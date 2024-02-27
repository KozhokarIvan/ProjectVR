import { FriendInfo } from "@/types";
import Friend from "./Friend";
import TitledCard from "@/components/TitledCard";

export interface FriendsBarProps {
  friends: FriendInfo[];
}

export default function FriendsBar({ friends }: FriendsBarProps) {
  return (
    <TitledCard
      collectionWrapperClassName="grid grid-cols-2 gap-3"
      title="Friends"
      itemsNumber={friends.length}
    >
      {friends.map((friend, index) => (
        <Friend key={index} username={friend.username} avatar={friend.avatar} />
      ))}
    </TitledCard>
  );
}
