type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type Fn = (value: JSONValue) => number

/**
 * 2724. Sort By
 * 
 * {@link https://leetcode.com/problems/sort-by See more}
 */
export function sortBy(arr: JSONValue[], fn: Fn): JSONValue[] {
  arr.sort((x, y) => fn(x) - fn(y));
  return arr;
}
