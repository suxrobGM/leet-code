type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type Obj = Record<string, JSONValue> | JSONValue[];

/**
 * 2727. Is Object Empty
 * 
 * {@link https://leetcode.com/problems/is-object-empty See more}
 */
export function isEmpty(obj: Obj): boolean {
  return Object.keys(obj).length === 0;
}
