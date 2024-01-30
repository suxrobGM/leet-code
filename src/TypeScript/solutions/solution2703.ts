type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };

/**
 * 2703. Return Length of Arguments Passed
 * 
 * {@link https://leetcode.com/problems/return-length-of-arguments-passed See more}
 */
export function argumentsLength(...args: JSONValue[]): number {
  return args.length;
}
