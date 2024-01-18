import ProfileHeader from "@/app/users/[username]/ProfileHeader";
import FriendsBar from "./FriendsBar";
import TitledIconsCard from "../../../components/TitledIconsCard";
import ProfileFeed from "./ProfileFeed";
import { UserDetails } from "@/types";
import { FriendStatus } from "@/types/enums/FriendStatus";

export default function Page({ params }: { params: { username: string } }) {
  const user: UserDetails = {
    userGuid: "id",
    username: params.username,
    avatar: "https://i.pravatar.cc/300",
    friendStatus: FriendStatus.Stranger,
    vrsets: [
      {
        vrSetId: 0,
        vrSetName: "Meta Quest 2",
        vrSetIcon:
          "https://cdn.mos.cms.futurecdn.net/3tHJyGRakZSUbsQSgpqj3B.jpg",
        isFavorite: true,
      },
      {
        vrSetId: 1,
        vrSetName: "Meta Quest Pro",
        vrSetIcon:
          "https://wavypack.com/wp-content/uploads/2022/10/meta1-732x732.jpg",
        isFavorite: false,
      },
      {
        vrSetId: 2,
        vrSetName: "Meta Quest 3",
        vrSetIcon:
          "https://preview.free3d.com/img/2019/02/2188275829300004551/7br30t7k-900.jpg",
        isFavorite: true,
      },
      {
        vrSetId: 3,
        vrSetName: "Valve Index VR Kit",
        vrSetIcon:
          "https://cf.shopee.co.th/file/e56de62ec3d3a8fc90192786bb5d45a2",
        isFavorite: true,
      },
      {
        vrSetId: 4,
        vrSetName: "Htc Vive Pro",
        vrSetIcon:
          "https://cdn.shopify.com/s/files/1/0570/6563/6015/products/vive-pro-full-kit-side_1445x.jpg?v=1622601723",
        isFavorite: false,
      },
      {
        vrSetId: 5,
        vrSetName: "Htc Vive Pro 2",
        vrSetIcon:
          "https://www.robotistan.com/htc-vive-pro2-full-kit-38659-10-B.jpg",
        isFavorite: true,
      },
    ],
    games: [
      {
        gameId: 0,
        gameName: "Skyrim VR",
        gameIcon:
          "https://steamuserimages-a.akamaihd.net/ugc/1043093962826688663/4E945777E1822C8979CD679DDCCCD44C822A8BCB/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false",
        isFavorite: true,
      },
      {
        gameId: 1,
        gameName: "Fallout 4 VR",
        gameIcon:
          "https://steamuserimages-a.akamaihd.net/ugc/2057618192240916199/8F24AAC05F4485CA8C49D4064362BB6B91960D16/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true",
        isFavorite: true,
      },
      {
        gameId: 2,
        gameName: "Beat Saber",
        gameIcon:
          "https://steamuserimages-a.akamaihd.net/ugc/786352192200116789/D2244F357EC1456DEEB6F4AB15F8553C10F9F8DC/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false",
        isFavorite: true,
      },
      {
        gameId: 3,
        gameName: "The Forest",
        gameIcon:
          "https://images.discordapp.net/icons/556971445897396224/866ab404fa90cb84066fd06903c7c692.png?size=512",
        isFavorite: false,
      },
    ],
    registeredAt: new Date(Date.now()),
    friends: [
      {
        username: "somefriend",
        avatar: "https://i.pravatar.cc/301",
      },
      {
        username: "username",
      },
      {
        username: "gabenewell",
        avatar: "https://i.pravatar.cc/303",
      },
      {
        username: "paveldurove",
        avatar: "https://i.pravatar.cc/304",
      },
    ],
  };
  return (
    <main className="grid gap-10 mx-14">
      <ProfileHeader
        userGuid={user.userGuid}
        username={user.username}
        avatar={user.avatar}
        registeredAt={user.registeredAt}
        friendStatus={user.friendStatus}
      />
      <div className="grid gap-10 grid-cols-[1fr_3fr]">
        <FriendsBar friends={user.friends} />
        <div className="grid gap-4">
          <div className="grid gap-4 grid-cols-2">
            <TitledIconsCard
              title={`Devices (${user.vrsets.length})`}
              items={user.vrsets.map(vrset => ({
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
    </main>
  );
}
