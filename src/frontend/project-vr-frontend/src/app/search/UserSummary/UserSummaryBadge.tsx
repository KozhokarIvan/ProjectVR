import { Tooltip, Image } from "@nextui-org/react";

export interface UserSummaryBadgeProps {
  image?: string;
  isFavorite: boolean;
  text: string;
}

export default function UserSummaryBadge(props: UserSummaryBadgeProps) {
  const { text, image, isFavorite } = props;
  return (
    <Tooltip
      className={isFavorite ? "bg-yellow-400 text-zinc-900" : ""}
      content={text}
    >
      <Image
        className={isFavorite ? "border-2 border-yellow-400" : ""}
        width={46}
        src={image}
        alt={text}
      />
    </Tooltip>
  );
}
