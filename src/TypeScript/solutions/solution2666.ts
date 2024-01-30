type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type OnceFn = (...args: JSONValue[]) => JSONValue | undefined;

/**
 * 2666. Allow One Function Call
 * 
 * {@link https://leetcode.com/problems/allow-one-function-call See more}
 */
export function once(fn: Function): OnceFn {
  let called = false;
  
  return (...args) => {
    if (!called) {
      called = true;
      return fn(...args);
    }

    return undefined;
  }
}
