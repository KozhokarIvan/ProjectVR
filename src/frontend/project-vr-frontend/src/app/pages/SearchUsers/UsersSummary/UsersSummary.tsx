import { Grid, Spacer } from "@nextui-org/react";
import UserSummary from "@/app/pages/SearchUsers/UserSummary/UserSummary";
import { UserInfo } from "@/app/pages/SearchUsers/SearchUsers";

export interface UsersSummary{
    users: UserInfo[]
}

export default function UsersSummary(props: UsersSummary){
    
    const users = props.users;

    return(
        <Grid.Container
        direction="column"
        justify="center"
        alignItems="center"
        gap={3}
        >
            {users.map(user =>{
                return(
                <Grid
                md={9}
                key={user.guid}
                >
                    <UserSummary
                    key={user.guid} 
                    avatar={user.avatar ?? "https://i.pravatar.cc/101"} 
                    username={user.username} 
                    vrsets={user.vrSets} 
                    games={user.games}/>
                    <Spacer y={1}
                    />
                </Grid>
                );
            })}
        </Grid.Container>
    );
}