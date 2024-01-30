type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type Fn = (...args: JSONValue[]) => void;

/**
 * 2715. Timeout Cancellation
 * 
 * {@link https://leetcode.com/problems/timeout-cancellation See more}
 */
export function cancellable(fn: Fn, args: JSONValue[], t: number): Function {
  const timer = setTimeout(() => fn(...args), t);
  return () => clearTimeout(timer);
}
