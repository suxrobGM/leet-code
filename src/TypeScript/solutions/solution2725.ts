type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type Fn = (...args: JSONValue[]) => void;

/**
 * 2725. Interval Cancellation
 * 
 * {@link https://leetcode.com/problems/interval-cancellation See more}
 */
export function cancellable(fn: Fn, args: JSONValue[], t: number): Function {
  fn(...args);
  const timer = setInterval(() => fn(...args), t);
  return () => clearInterval(timer);
}
