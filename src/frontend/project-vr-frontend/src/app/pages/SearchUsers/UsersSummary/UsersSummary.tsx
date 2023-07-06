import { Container, Spacer } from "@nextui-org/react";
import UserSummary from "@/app/pages/SearchUsers/UserSummary/UserSummary";
import { UserInfo } from "@/app/pages/SearchUsers/SearchUsers";

export interface UsersSummary{
    users: UserInfo[]
}

export default function UsersSummary(props: UsersSummary){
    
    const users = props.users;

    return(
        <Container>
            {users.map((user, index) =>{
                return(
                <>
                    <UserSummary
                    key={user.guid} 
                    avatar={`https://i.pravatar.cc/${101+index}`} 
                    username={user.username} 
                    vrsets={user.vrSets} 
                    games={user.games}/>
                    <Spacer y={1}
                    />
                </>
                );
            })}
        </Container>
    );
}