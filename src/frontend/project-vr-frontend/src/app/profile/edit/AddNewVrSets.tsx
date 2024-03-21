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
import { SetStateAction, useEffect, useState } from "react";

export interface AddNewVrSetsProps {
  vrSets: VrSet[];
  setVrSets: (value: SetStateAction<VrSet[]>) => void;
  isVrSetsLoaded: boolean;
  userVrSets: UserVrSet[];
  setUserVrSets: (value: SetStateAction<UserVrSet[]>) => void;
  selectedVrSets: VrSet[];
  setSelectedVrSets: (value: SetStateAction<VrSet[]>) => void;
  selectedKeys: any;
  setSelectedKeys: (value: SetStateAction<any>) => void;
  buttonProps: ButtonProps;
  className?: string;
}

export default function AddNewVrSets({
  vrSets,
  setVrSets,
  isVrSetsLoaded,
  userVrSets,
  setUserVrSets,
  selectedVrSets,
  setSelectedVrSets,
  selectedKeys,
  setSelectedKeys,
  buttonProps,
  className,
}: AddNewVrSetsProps) {
  const [queryText, setQueryText] = useState<string>("");
  const [searchResults, setSearchResult] = useState<VrSet[]>([]);
  const searchVrSets = async (query: string) => {
    if (query.length < 3) return;
    setSearchResult(
      vrSets.filter(vs => vs.name.toUpperCase().includes(query.toUpperCase()))
    );
  };
  useEffect(() => {
    setSearchResult(vrSets);
    setSelectedVrSets([]);
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
        onChange={async (event: { target: { value: string } }) => {
          try {
            const newText = event.target.value;
            setQueryText(newText);
            searchVrSets(newText);
          } catch (err) {
            console.error("Error:", err);
          }
        }}
        onClear={async () => {
          try {
            setQueryText("");
          } catch (err) {
            console.error("Error:", err);
          }
        }}
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
              <TableRow
                key={vs.id}
                onClick={() => {
                  if (selectedVrSets.map(v => v.id).includes(vs.id))
                    setSelectedVrSets(
                      selectedVrSets.filter(v => v.id != vs.id)
                    );
                  else setSelectedVrSets([...selectedVrSets, vs]);
                }}
              >
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
          fullWidth={false}
          variant="ghost"
          color="success"
          className={selectedVrSets.length > 0 ? "" : "hidden"}
          onClick={() => {
            {
              setUserVrSets([
                ...userVrSets,
                ...selectedVrSets.map(vs => {
                  return {
                    vrSetId: vs.id,
                    vrSetName: vs.name,
                    vrSetIcon: vs.icon,
                    isFavorite: false,
                  };
                }),
              ]);
              setVrSets(
                vrSets.filter(
                  vs => !selectedVrSets.map(v => v.id).includes(vs.id)
                )
              );
            }
          }}
        >
          Add selected vr sets to your collection
        </Button>
        <Button
          {...buttonProps}
          fullWidth={false}
          variant="ghost"
          color="danger"
          className={selectedVrSets.length > 0 ? "" : "hidden"}
          onClick={() => {
            setSelectedVrSets([]);
            setSelectedKeys([]);
          }}
        >
          Deselect all
        </Button>
      </div>
    </div>
  );
}
