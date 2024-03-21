import { VRSETS_ROUTE } from "./routes";
import { HOST } from "./urls";
import { VrSet } from "@/types";

export const getVrSets = async (
  limit: number,
  offset?: number
): Promise<VrSet[]> => {
  const requestParameters = {
    method: "get",
  };
  const requestUrl = HOST + VRSETS_ROUTE + `?limit=${limit}&offset=${offset}`;
  try {
    const response = await fetch(requestUrl, requestParameters);
    const vrSets: VrSet[] = await response.json();
    return vrSets;
  } catch (err) {
    console.error(err);
    throw err;
  }
};

export const searchVrSets = async (
  query: string,
  limit: number,
  offset?: number
): Promise<VrSet[]> => {
  const requestParameters = {
    method: "get",
  };
  const requestUrl =
    HOST + VRSETS_ROUTE + `?query=${query}&limit=${limit}&offset=${offset}`;
  try {
    const response = await fetch(requestUrl, requestParameters);
    const vrSets: VrSet[] = await response.json();
    return vrSets;
  } catch (err) {
    console.error(err);
    throw err;
  }
};
