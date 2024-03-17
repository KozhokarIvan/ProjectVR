import SvgIcon, { SvgIconProps } from "./SvgIcon";
export interface HoverIconProps {
  svgProps: SvgIconProps;
  opacity?: number;
  opacityHover?: number;
  opacityActive?: number;
}

export default function HoverIcon({
  svgProps,
  opacity,
  opacityHover,
  opacityActive,
}: HoverIconProps) {
  const hoverClassName = `cursor-pointer opacity-${
    opacity ?? 80
  } hover:opacity-${opacityHover ?? 90} active:opacity-${opacityActive ?? 100}`;
  const props: SvgIconProps = {
    ...svgProps,
    props: {
      ...svgProps.props,
      className: [svgProps.props?.className, hoverClassName].join(" "),
    },
  };
  return <SvgIcon {...props} />;
}
