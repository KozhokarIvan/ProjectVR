import { Button, Card, CardBody, Divider } from "@nextui-org/react";
import { PropsWithChildren } from "react";

export interface TitledCardProps {
  title: string;
  itemsNumber: number;
  className?: string;
  collectionWrapperClassName?: string;
  editUrl?: string;
}

export default function TitledCard({
  children,
  title,
  itemsNumber,
  className,
  collectionWrapperClassName: collectionClassNames,
  editUrl,
}: PropsWithChildren<TitledCardProps>) {
  return (
    <Card radius="none" className="bg-transparent border-1.5 border-default">
      <CardBody className={"min-h-60" + className}>
        <div className="mb-3 flex justify-between">
          <h6 className="text-xl block">
            {title}
            {!itemsNumber ? (
              ""
            ) : (
              <span className="text-2xl text-default"> {itemsNumber}</span>
            )}
          </h6>
          {editUrl ? <Button variant="light" radius="none"></Button> : ""}
        </div>
        <Divider className="mb-4 mt-2" />
        <div className={collectionClassNames}>{children}</div>
      </CardBody>
    </Card>
  );
}
