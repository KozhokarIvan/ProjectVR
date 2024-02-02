import CloseIcon from "@/components/icons/CloseIcon";
import LabeledInput from "@/components/forms/LabeledInput";
import { useLabel } from "@/hooks/use-label";
import { Badge, Image, Input, InputProps } from "@nextui-org/react";
import { useState } from "react";

export interface AvatarUploadProps {
  avatar: string;
  setAvatar: (avatar: string) => void;
  labelClassName?: string;
  imgClassName?: string;
  inputProps?: InputProps;
}

export default function AvatarUpload({
  avatar,
  setAvatar,
  labelClassName,
  imgClassName,
  inputProps,
}: AvatarUploadProps) {
  const defaultClickText = "Paste avatar link here";
  const [label, setLabel] = useLabel("primary", defaultClickText);
  const [isAvatarValid, setIsAvatarValid] = useState(false);
  const resetAvatar = () => {
    setAvatar("");
    setIsAvatarValid(false);
    setLabel("primary", defaultClickText);
  };
  const fetchImage = (url: string) => {
    setIsAvatarValid(true);
    setLabel("primary", defaultClickText);
  };
  if (isAvatarValid)
    return (
      <Badge
        color="danger"
        content={<CloseIcon />}
        className="hover:cursor-pointer bg-opacity-80 hover:bg-opacity-90 active:bg-opacity-100 p-1"
        onClick={resetAvatar}
      >
        <Image height={"100%"} src={avatar} className={imgClassName} />
      </Badge>
    );
  return (
    <>
      <LabeledInput
        label={{
          color: label.color,
          message: label.color == "danger" ? label.message : "",
        }}
        value={avatar}
        setValue={setAvatar}
        className={labelClassName}
        inputProps={{
          ...inputProps,
          isClearable: true,
          placeholder: label.message,
          value: avatar,
          onChange: event => {
            const inputText = event.target.value;
            setAvatar(inputText);
            if (!inputText.match(/^https:\/\/.*\.(jpeg|jpg|png)$/)) return;
            fetchImage(inputText);
          },
          onClear: resetAvatar,
          onBlur: () => {
            if (avatar && avatar.match(/^https:\/\/.*\.$/)) fetchImage(avatar);
          },
        }}
      />
      <img
        className={`hidden`}
        onLoad={() => setIsAvatarValid(true)}
        onError={() => setIsAvatarValid(false)}
        src={avatar}
      />
    </>
  );
}
