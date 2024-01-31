"use client";
import ProfileHeader from "@/app/users/[username]/ProfileHeader";
import FriendsBar from "./FriendsBar";
import TitledIconsCard from "@/components/TitledIconsCard";
import ProfileFeed from "./ProfileFeed";
import { UserDetails } from "@/types";
import { useEffect, useState } from "react";
import { getUser } from "@/api/usersApi";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { Spinner } from "@nextui-org/react";

export default function Page({ params }: { params: { username: string } }) {
  const [user, setUser] = useState<UserDetails | null>(null);
  const { user: loggedUser } = useLoggedUser();
  useEffect(() => {
    getUser(params.username, loggedUser?.userGuid).then(user => {
      setUser(user);
    });
  }, []);
  return (
    <main className="grid gap-10 mx-14">
      {user ? (
        <>
          <ProfileHeader
            userGuid={user.guid}
            username={user.username}
            avatar={user.avatar}
            registeredAt={new Date(user.createdAt)}
            friendStatus={user.friendStatus}
          />
          <div className="grid gap-10 grid-cols-[1fr_3fr]">
            <FriendsBar friends={user.friends} />
            <div className="grid gap-4">
              <div className="grid gap-4 grid-cols-2">
                <TitledIconsCard
                  title={`Devices (${user.vrSets.length})`}
                  items={user.vrSets.map(vrset => ({
                    text: vrset.vrSetName,
                    image: vrset.vrSetIcon,
                    isFavorite: vrset.isFavorite,
                  }))}
                />
                <TitledIconsCard
                  title={`Games (${user.games.length})`}
                  items={user.games.map(game => ({
                    text: game.gameName,
                    image: game.gameIcon,
                    isFavorite: game.isFavorite,
                  }))}
                />
              </div>
              <ProfileFeed />
            </div>
          </div>
        </>
      ) : (
        <Spinner
          classNames={{
            label: "text-3xl font-bold bg-white",
          }}
          label="Loading..."
          className="mt-32"
        />
      )}
    </main>
  );
}
