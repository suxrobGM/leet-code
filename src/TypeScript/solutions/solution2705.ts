type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type Obj = Record<string, JSONValue> | Array<JSONValue>;

/**
 * 2705. Compact Object
 * 
 * {@link https://leetcode.com/problems/compact-object See more}
 */
export function compactObject(obj: Obj): Obj {
  if (typeof obj !== 'object' || obj == null) {
    return obj;
  }
  if (Array.isArray(obj)) {
    return obj.filter(Boolean).map((value) => compactObject(value as Obj));
  }

  const resultObj: any = {};

  for (const key in obj) {
    const value = compactObject(obj[key] as Obj);

    if (value) {
      resultObj[key] = value;
    }
  }

  return resultObj;
}
