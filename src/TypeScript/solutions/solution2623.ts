type Fn = (...params: number[]) => number;

/**
 * 2623. Memoize
 * 
 * {@link https://leetcode.com/problems/memoize See more}
 */
export function memoize(fn: Fn): Fn {
  const cache = new Map<string, number>();

  return (...args: number[]) => {
    const key = args.join('-');

    if (cache.has(key)) {
      return cache.get(key)!;
    }

    const result = fn(...args);
    cache.set(key, result);
    return result;
  }
}
