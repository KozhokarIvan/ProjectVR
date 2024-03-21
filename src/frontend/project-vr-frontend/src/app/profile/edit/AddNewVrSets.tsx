import { UserVrSet, VrSet } from "@/types";
import {
  Button,
  ButtonProps,
  Image,
  Input,
  ScrollShadow,
  Spinner,
  Table,
  TableBody,
  TableCell,
  TableColumn,
  TableHeader,
  TableRow,
} from "@nextui-org/react";
import { useEffect, useState } from "react";

export interface AddNewVrSetsProps {
  vrSets: VrSet[];
  isVrSetsLoaded: boolean;
  userVrSets: UserVrSet[];
  selectedVrSets: VrSet[];
  addSelectionToUserVrSets: () => void;
  cancelSelection: () => void;
  addVrSetToSelection: (vrSet: VrSet) => void;
  buttonProps: ButtonProps;
  className?: string;
}

export default function AddNewVrSets({
  vrSets,
  isVrSetsLoaded,
  userVrSets,
  selectedVrSets,
  addSelectionToUserVrSets,
  cancelSelection,
  addVrSetToSelection,
  buttonProps,
  className,
}: AddNewVrSetsProps) {
  buttonProps = {
    ...buttonProps,
    fullWidth: false,
    variant: "ghost",
    className: selectedVrSets.length > 0 ? "" : "hidden",
  };
  const [queryText, setQueryText] = useState<string>("");
  const [searchResults, setSearchResult] = useState<VrSet[]>([]);
  const [selectedKeys, setSelectedKeys] = useState<any>();
  const searchVrSets = async (query: string) => {
    if (query.length < 3) return;
    setSearchResult(
      vrSets.filter(vs => vs.name.toUpperCase().includes(query.toUpperCase()))
    );
  };
  const onInputChange = async (event: { target: { value: string } }) => {
    const newText = event.target.value;
    setQueryText(newText);
    searchVrSets(newText);
  };
  useEffect(() => {
    setSearchResult(vrSets);
    setSelectedKeys([]);
  }, [vrSets, userVrSets]);
  useEffect(() => {
    if (queryText.length == 0) setSearchResult(vrSets);
  }, [queryText]);
  return (
    <div className={className}>
      <Input
        variant="bordered"
        placeholder="Find a user..."
        color="primary"
        radius="none"
        size="sm"
        isClearable
        value={queryText}
        onChange={onInputChange}
        onClear={() => setQueryText("")}
      />
      <ScrollShadow className="h-[520px]">
        <Table
          removeWrapper
          hideHeader
          selectionMode="multiple"
          selectedKeys={selectedKeys}
          onSelectionChange={setSelectedKeys}
          classNames={{
            td: [
              "group-data-[first=true]:first:before:rounded-none",
              "group-data-[first=true]:last:before:rounded-none",
              "group-data-[middle=true]:before:rounded-none",
              "group-data-[last=true]:first:before:rounded-none",
              "group-data-[last=true]:last:before:rounded-none",
            ],
          }}
        >
          <TableHeader>
            <TableColumn>Name</TableColumn>
          </TableHeader>
          <TableBody
            isLoading={!isVrSetsLoaded}
            loadingContent={<Spinner label="Loading..." />}
          >
            {searchResults.map(vs => (
              <TableRow key={vs.id} onClick={() => addVrSetToSelection(vs)}>
                <TableCell className="flex gap-3 items-center">
                  <Image src={vs.icon} width={150}></Image>
                  <h6 className="text-xl">{vs.name}</h6>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </ScrollShadow>
      <div className={`flex justify-between mt-2 mb-40 ${className}`}>
        <Button
          {...buttonProps}
          color="success"
          onClick={() => addSelectionToUserVrSets()}
        >
          Add selected vr sets to your collection
        </Button>
        <Button
          {...buttonProps}
          color="danger"
          onClick={() => cancelSelection()}
        >
          Deselect all
        </Button>
      </div>
    </div>
  );
}
