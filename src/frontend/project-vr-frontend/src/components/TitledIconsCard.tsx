import Icon, { IconProps } from "@/components/Icon";
import TitledCard from "@/components/TitledCard";

export interface TitledIconsCard {
  title: string;
  items: IconProps[];
}

export default function TitledIconsCard({ title, items }: TitledIconsCard) {
  return (
    <TitledCard
      title={title}
      collectionWrapperClassName="grid grid-cols-3 gap-4"
      itemsNumber={items.length}
    >
      {items.map((item, index) => (
        <Icon
          key={index}
          text={item.text}
          image={item.image}
          isFavorite={item.isFavorite}
          width={80}
        />
      ))}
    </TitledCard>
  );
}
