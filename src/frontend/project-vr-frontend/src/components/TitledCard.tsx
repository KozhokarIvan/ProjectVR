import { Button, Card, CardBody, Divider } from "@nextui-org/react";
import React, { FC, PropsWithChildren, ReactNode } from "react";

export interface TitledCardProps {
  title: string;
  className?: string;
  collectionWrapperClassName?: string;
  editUrl?: string;
}

export default function TitledCard({
  children,
  title,
  className,
  collectionWrapperClassName: collectionClassNames,
  editUrl,
}: PropsWithChildren<TitledCardProps>) {
  return (
    <Card radius="none">
      <CardBody className={"min-h-60" + className}>
        <div className="mb-3 flex justify-between">
          <h6 className="text-xl block">{title}</h6>
          {editUrl ? <Button variant="light" radius="none"></Button> : ""}
        </div>
        <Divider className="mb-4 mt-2" />
        <div className={collectionClassNames}>{children}</div>
      </CardBody>
    </Card>
  );
}
