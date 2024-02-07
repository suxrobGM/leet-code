type F = (...args: number[]) => void;

/**
 * 2627. Debounce
 * 
 * {@link https://leetcode.com/problems/debounce See more}
 */
export function debounce(fn: F, t: number): F {
  let timerId: any = null;

  return (...args) => {
    clearTimeout(timerId)
    timerId = setTimeout(fn, t, ...args);
  };
}
