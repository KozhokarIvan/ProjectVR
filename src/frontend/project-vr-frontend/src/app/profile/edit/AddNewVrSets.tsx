import { UserVrSet, VrSet } from "@/types";
import {
  Button,
  ButtonProps,
  Image,
  Input,
  InputProps,
  ScrollShadow,
  Spinner,
  Table,
  TableBody,
  TableCell,
  TableColumn,
  TableHeader,
  TableProps,
  TableRow,
} from "@nextui-org/react";
import { useEffect, useRef, useState } from "react";

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
  }, [vrSets, userVrSets]);
  useEffect(() => {
    if (queryText.length == 0) setSearchResult(vrSets);
  }, [queryText]);
  const inputProps: InputProps = {
    variant: "bordered",
    placeholder: "Find a user...",
    color: "primary",
    radius: "none",
    size: "sm",
    isClearable: true,
    value: queryText,
    onChange: onInputChange,
    onClear: () => setQueryText(""),
  };
  const tableProps: TableProps = {
    removeWrapper: true,
    hideHeader: true,
    selectionMode: "multiple",
    selectedKeys: selectedVrSets.map(vs => vs.id.toString()),
    classNames: {
      td: [
        "group-data-[first=true]:first:before:rounded-none",
        "group-data-[first=true]:last:before:rounded-none",
        "group-data-[middle=true]:before:rounded-none",
        "group-data-[last=true]:first:before:rounded-none",
        "group-data-[last=true]:last:before:rounded-none",
      ],
    },
  };
  const addButtonProps: ButtonProps = {
    ...buttonProps,
    color: "success",
    onClick: () => addSelectionToUserVrSets(),
  };
  const deselectButtonProps: ButtonProps = {
    ...buttonProps,
    color: "danger",
    onClick: () => cancelSelection(),
  };
  return (
    <div className={className}>
      <Input {...inputProps} />
      <ScrollShadow className="h-[520px]">
        <Table {...tableProps}>
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
        <Button {...addButtonProps}>
          Add selected vr sets to your collection
        </Button>
        <Button {...deselectButtonProps}>Deselect all</Button>
      </div>
    </div>
  );
}
