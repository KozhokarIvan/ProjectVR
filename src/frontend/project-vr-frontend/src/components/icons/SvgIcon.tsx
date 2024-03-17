import { ComponentType, SVGProps } from "react";

export interface SvgIconProps {
  Icon: ComponentType<SVGProps<SVGSVGElement>>;
  props: SVGProps<SVGSVGElement>;
}

export default function SvgIcon({ Icon, props }: SvgIconProps) {
  return <Icon {...props} />;
}
