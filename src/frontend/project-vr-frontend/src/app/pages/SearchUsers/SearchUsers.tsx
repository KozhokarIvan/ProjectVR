import { useState, useEffect } from "react";
import { Spacer, Container, Text } from "@nextui-org/react";
import Header from "@/app/components/Header/Header";
import UsersSummary from "@/app/pages/SearchUsers/UsersSummary/UsersSummary";

export interface Game{
  gameId: number,
  name: string,
  isFavorite: boolean,
  rating?: number
}

export interface VrSet{
  vrSetId: number,
  name: string,
  isFavorite: boolean
}

export interface UserInfo{
  guid: string,
  username: string,
  avatar?: string,
  games: Game[],
  vrSets: VrSet[]
}

export default function SearchUsers(){

  const staticUsers = [
    {
      "guid": "0d33e28a-69e7-400e-87d6-f161935de5c4",
      "username": "questproenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 63,
          "isFavorite": false
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 55,
          "isFavorite": false
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 59,
          "isFavorite": false
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 50,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 2,
          "name": "Meta Quest Pro",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "4f9cf3d6-554d-4662-a896-7b8907688a6a",
      "username": "quest2enjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 98,
          "isFavorite": true
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 87,
          "isFavorite": true
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 90,
          "isFavorite": true
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 65,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 1,
          "name": "Meta Quest 2",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "59cd92da-6b8f-40b3-ab08-a3cb1cab1532",
      "username": "skyrimenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 100,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 3,
          "name": "Meta Quest 3",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "5a560c3a-6d49-4442-a372-a51e99a27f74",
      "username": "forestenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 8,
          "name": "The Forest",
          "rating": 100,
          "isFavorite": true
        }
      ],
      "vrSets": [
        {
          "vrSetId": 3,
          "name": "Meta Quest 3",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "7aea3171-5b7c-48ad-b68d-f191151bbc58",
      "username": "valveindexenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 100,
          "isFavorite": true
        }
      ],
      "vrSets": [
        {
          "vrSetId": 4,
          "name": "Valve Index VR Kit",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "86628830-8827-4a4d-b7ed-fb5fff025f1a",
      "username": "beatsaberenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 100,
          "isFavorite": true
        }
      ],
      "vrSets": [
        {
          "vrSetId": 3,
          "name": "Meta Quest 3",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8",
      "username": "vrenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 95,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 3,
          "name": "Meta Quest 3",
          "isFavorite": false
        },
        {
          "vrSetId": 4,
          "name": "Valve Index VR Kit",
          "isFavorite": false
        },
        {
          "vrSetId": 6,
          "name": "Htc Vive Pro 2",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "a028785e-4dc5-434f-8cd1-828cbc2f1169",
      "username": "falloutenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 100,
          "isFavorite": true
        }
      ],
      "vrSets": [
        {
          "vrSetId": 3,
          "name": "Meta Quest 3",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2",
      "username": "viveenjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 74,
          "isFavorite": false
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 69,
          "isFavorite": false
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 62,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 5,
          "name": "Htc Vive Pro",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "d0f08641-b16c-45a2-a8e0-2af5b33aefd5",
      "username": "vive2enjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 73,
          "isFavorite": false
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 64,
          "isFavorite": false
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 47,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 6,
          "name": "Htc Vive Pro 2",
          "isFavorite": false
        }
      ]
    },
    {
      "guid": "fd26857b-9be1-47d3-a518-d834beedf746",
      "username": "quest3enjoyer",
      "avatar": null,
      "games": [
        {
          "gameId": 3,
          "name": "Skyrim VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 4,
          "name": "Fallout 4 VR",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 1,
          "name": "Beat Saber",
          "rating": 100,
          "isFavorite": true
        },
        {
          "gameId": 6,
          "name": "Blade and Sorcery",
          "rating": 77,
          "isFavorite": false
        }
      ],
      "vrSets": [
        {
          "vrSetId": 3,
          "name": "Meta Quest 3",
          "isFavorite": false
        }
      ]
    }
  ];

  const [users, setUsers] = useState<UserInfo[]>([]);

  useEffect(() => {
    const fetchUsers = async () => {
      const data = await fetch('https://localhost:8080/api/users', {
        method: 'get'
      });

      const users = await data.json();
      setUsers(users);
    };

    fetchUsers().catch((err)=>console.log("Error: ", err));
  }, []);

  return(
      <main>
          <Header setUsers={setUsers}/>
          <Spacer y={3}/>
          {
            users && users.length > 0
            ?
            <UsersSummary users={users}/>
            :
            <Container
            justify="center"
            >
              <Text
              h2
              >
                No users found
              </Text>
            </Container>
          }
      </main>
  );
}