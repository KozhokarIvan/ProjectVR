import { Tooltip, Image } from "@nextui-org/react";

export interface IconProps {
  text: string;
  image?: string;
  isFavorite: boolean;
  width?: number;
}
export default function Icon(props: IconProps) {
  const { text, image, isFavorite } = props;
  const width = props.width || 46;
  return (
    <Tooltip
      className={isFavorite ? "bg-yellow-400 text-zinc-900" : ""}
      content={text}
    >
      <Image
        className={isFavorite ? "border-2 border-yellow-400" : ""}
        width={width}
        src={image}
        alt={text}
      />
    </Tooltip>
  );
}
