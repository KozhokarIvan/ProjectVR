import { Tooltip, Avatar } from "@nextui-org/react"

export interface UserSummaryBadgeProps{
    image?: string,
    isFavorite: boolean,
    text: string
}

export default function UserSummaryBadge(props: UserSummaryBadgeProps){

    const { text, image, isFavorite} = props;

    return(
        <Tooltip
        content={text}
        >
            <Avatar 
                    color="secondary"
                    squared
                    pointer
                    src={image}
                    bordered = {isFavorite}
                    text={text}
                    textColor={isFavorite ? "default" : "warning"}
            />
        </Tooltip>
    );
}