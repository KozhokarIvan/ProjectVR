import { Navbar, Link, Text, Input, Button, Switch, User, changeTheme, useTheme } from "@nextui-org/react";
import { FC, ReactElement } from 'react';
import { UserInfo } from "@/app/pages/SearchUsers/SearchUsers";

export interface HeaderProps{
    setUsers: (users: UserInfo[]) => void
}

export default function Header(props: HeaderProps) : ReactElement<HeaderProps, FC> {
    const { setUsers } = props;
    const { type, isDark } = useTheme();

    const handleChange = () => {
        const nextTheme = isDark ? 'light' : 'dark';
        window.localStorage.setItem('data-theme', nextTheme);
        changeTheme(nextTheme);
    }

    const searchUsers = async (searchText: string) => {

        if(searchText.length == 0){
            await fetchRandomUsers();
            return
        }

        if(searchText.length < 3){
            return;
        }
        const baseUrl = "https://localhost:8080/api/"; 
        const requestParameters = {
            method: "get"
        };
        
        const vrSetsRequest = baseUrl + `users${searchText ? `?vrset=${searchText}` : ""}`;
        const responseVrSets = await fetch(vrSetsRequest, requestParameters);
        const usersByVrSets = await responseVrSets.json();

        const gamesRequest = baseUrl + `users${searchText ? `?game=${searchText}` : ""}`;
        const responseGames = await fetch(gamesRequest, requestParameters);
        const usersByGames = await responseGames.json();

        const users = usersByGames.concat(usersByVrSets);

        setUsers(users);
    };
    
    const fetchRandomUsers = async() => {
        const request = "https://localhost:8080/api/users/random";
        const response = await fetch(request,
            {
                method: "get"
            });
        const users = await response.json();
        setUsers(users);
    }

    return(
        <Navbar 
        as="header"
        variant = "sticky"
        >
            <Navbar.Brand>
                <Link 
                href="#"
                >
                    <Text h2 color="secondary">
                        ProjectVR
                    </Text>
                </Link>
            </Navbar.Brand>
            <Navbar.Content>
                <Input
                bordered
                placeholder="Find a user..."
                color="secondary"
                clearable
                onChange={async (event) => {await searchUsers(event.target.value)}}
                />
                <Button 
                bordered 
                color="secondary" 
                auto
                onPress={async (event) => {await fetchRandomUsers()}}
                >
                    Random
                </Button>
            </Navbar.Content>
            <Navbar.Content>
                <Switch
                color="secondary"
                checked = {isDark}
                onChange = {handleChange}
                />
                <Link href="#">
                    <User
                    name="username#1234"
                    size="lg"
                    zoomed
                    pointer
                    src="https://i.pravatar.cc/100"/>
                </Link>
            </Navbar.Content>
        </Navbar>
    );
}