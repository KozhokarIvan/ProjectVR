import { Card, CardBody } from "@nextui-org/react";

export default function ProfileFeed() {
  return (
    <Card radius="none">
      <CardBody>
        <p className="min-h-32 text-center text-xl">
          User has no recent activity...
        </p>
      </CardBody>
    </Card>
  );
}
