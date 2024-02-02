"use client";
import ProfileHeader from "@/components/ProfileHeader";
import TitledIconsCard from "@/components/TitledIconsCard";
import { UserDetails } from "@/types";
import { useEffect, useState } from "react";
import { getUser } from "@/api/usersApi";
import { useLoggedUser } from "@/hooks/use-logged-user";
import { Spinner } from "@nextui-org/react";
import FriendsBar from "@/components/FriendsBar";
import ProfileFeed from "@/components/ProfileFeed";
import { redirect } from "next/navigation";

export default function Page() {
  const [user, setUser] = useState<UserDetails | null>(null);
  const { user: loggedUser, isDone: isDoneGrappingLoggedUser } =
    useLoggedUser();
  useEffect(() => {
    if (!isDoneGrappingLoggedUser) return;
    if (!loggedUser) redirect("/login");
    getUser(loggedUser.username, loggedUser.userGuid).then(user => {
      setUser(user);
    });
  }, [loggedUser]);
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
            isEditableProfile
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
